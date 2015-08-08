namespace Lucene.Net.Documents
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