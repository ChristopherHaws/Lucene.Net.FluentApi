using System;
using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public class NumericFieldAttributeBuilder<T>
	{
		private readonly Document document;
		private readonly T value;
		private readonly FieldAttributeReflector fieldAttributeReflector;

		public NumericFieldAttributeBuilder(Document document, T value)
		{
			this.document = document;
			this.value = value;
			this.fieldAttributeReflector = new FieldAttributeReflector();
		}

		public void Build()
		{
			var fieldAttributeInfos = this.fieldAttributeReflector.GetNumericFieldAttributeInfosWithValues<T>(this.value);

			foreach (var fieldAttributeInfo in fieldAttributeInfos)
			{
				if (fieldAttributeInfo.Value is Int32)
				{
					var builder = this.document.Add((Int32) fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}

				if (fieldAttributeInfo.Value is Int64)
				{
					var builder = this.document.Add((Int64)fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}

				if (fieldAttributeInfo.Value is Single)
				{
					var builder = this.document.Add((Single)fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}

				if (fieldAttributeInfo.Value is Double)
				{
					var builder = this.document.Add((Double)fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}

				if (fieldAttributeInfo.Value is Boolean)
				{
					var builder = this.document.Add((Boolean)fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}

				if (fieldAttributeInfo.Value is DateTime)
				{
					var builder = this.document.Add((DateTime)fieldAttributeInfo.Value);

					if (fieldAttributeInfo.Settings.Store)
					{
						builder.Stored();
					}

					if (fieldAttributeInfo.Settings.Index)
					{
						builder.Indexed().WithPrecisionStep(fieldAttributeInfo.Settings.PrecisionStep);
					}

					builder.As(fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name);
				}
			}
		}
	}
}