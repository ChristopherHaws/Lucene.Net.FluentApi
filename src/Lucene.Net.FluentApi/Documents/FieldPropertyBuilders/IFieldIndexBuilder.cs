using Lucene.Net.Documents.FieldBuilders;

namespace Lucene.Net.Documents.FieldPropertyBuilders
{
	public interface IFieldIndexBuilder<out TFieldBuilder> where TFieldBuilder : IFieldBuilder
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