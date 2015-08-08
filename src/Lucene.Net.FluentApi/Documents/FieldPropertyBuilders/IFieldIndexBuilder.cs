using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldBuilders;

namespace Lucene.Net.Fluent.Documents.FieldPropertyBuilders
{
	internal interface IFieldIndexBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
	{
		/// <summary>
		/// 
		/// </summary>
		TFieldBuilder Index();

		/// <summary>
		/// 
		/// </summary>
		TFieldBuilder Analyzed();

		/// <summary>
		/// 
		/// </summary>
		TFieldBuilder WithoutNorms();

		/// <summary>
		/// 
		/// </summary>
		Field.Index ToFieldIndex();
	}
}