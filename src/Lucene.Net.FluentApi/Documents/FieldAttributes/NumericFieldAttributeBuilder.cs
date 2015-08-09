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
				if (fieldAttributeInfo.Value == null)
				{
					continue;
				}

				var field = new NumericField(
					fieldAttributeInfo.Settings.Name ?? fieldAttributeInfo.Name,
					fieldAttributeInfo.Settings.PrecisionStep,
					fieldAttributeInfo.Settings.Store ? Field.Store.YES : Field.Store.NO,
					fieldAttributeInfo.Settings.Index
				);

				if (fieldAttributeInfo.Value is Int32)
				{
					field.SetIntValue((Int32) fieldAttributeInfo.Value);
				}
				else if (fieldAttributeInfo.Value is Int64)
				{
					field.SetLongValue((Int64)fieldAttributeInfo.Value);
				}
				else if (fieldAttributeInfo.Value is Single)
				{
					field.SetFloatValue((Single)fieldAttributeInfo.Value);
				}
				else if (fieldAttributeInfo.Value is Double)
				{
					field.SetDoubleValue((Double)fieldAttributeInfo.Value);
				}
				else if (fieldAttributeInfo.Value is Boolean)
				{
					field.SetIntValue((Boolean)fieldAttributeInfo.Value ? 1 : 0);
				}
				else if (fieldAttributeInfo.Value is DateTime)
				{
					field.SetLongValue(((DateTime) fieldAttributeInfo.Value).Ticks);
				}
				else
				{
                    throw new InvalidOperationException($"{fieldAttributeInfo.Value.GetType().FullName} is not a valid numeric field type for '{typeof(T).FullName}.{fieldAttributeInfo.Name}'.");
                }

				this.document.Add(field);
			}
		}
	}
}