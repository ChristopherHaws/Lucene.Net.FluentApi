using System;
using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class FieldAttributeBuilder<T>
	{
		private readonly Document document;
		private readonly T value;
		private readonly FieldAttributeReflector fieldAttributeReflector;

		public FieldAttributeBuilder(Document document, T value)
		{
			this.document = document;
			this.value = value;
			this.fieldAttributeReflector = new FieldAttributeReflector();
		}

		public void Build()
		{
			var fieldAttributeInfos = this.fieldAttributeReflector.GetFieldAttributeInfosWithValues<T>(this.value);

			foreach (var fieldAttributeInfo in fieldAttributeInfos)
			{
				var value = fieldAttributeInfo.Value as String;
				if (value == null)
				{
					continue;
				}

				var builder = this.document.Add(value);

				if (fieldAttributeInfo.Settings.Store)
				{
					builder.Stored();
				}

				switch (fieldAttributeInfo.Settings.IndexMode)
				{
					case IndexMode.Analyzed:
						builder.Indexed().Analyzed().BoostBy(fieldAttributeInfo.Settings.Boost);
						break;
					case IndexMode.AnalyzedNoNorms:
						builder.Indexed().Analyzed().WithoutNorms().BoostBy(fieldAttributeInfo.Settings.Boost);
						break;
					case IndexMode.NotAnalyzed:
						builder.Indexed().BoostBy(fieldAttributeInfo.Settings.Boost);
						break;
					case IndexMode.NotAnalyzedNoNorms:
						builder.Indexed().WithoutNorms().BoostBy(fieldAttributeInfo.Settings.Boost);
						break;
				}
				
				builder.As(fieldAttributeInfo.Name);
			}
		}
	}
}