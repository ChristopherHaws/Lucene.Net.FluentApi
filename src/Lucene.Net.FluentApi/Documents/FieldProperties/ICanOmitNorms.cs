namespace Lucene.Net.Fluent.Documents.FieldProperties
{
	public interface ICanOmitNorms<out TResult>
	{
		/// <summary>
		/// Disable the storing of norms. 
		/// <para>No norms means that index-time field and document boosting and field length normalization are disabled.</para>
		/// <para>The benefit is less memory usage as norms take up one byte of RAM per indexed field for every document in the index, during searching.</para>
		/// <para>
		/// Note that once you index a given field with norms enabled, disabling norms will have no effect. In other words, for this to have the
		/// above described effect on a field, all instances of that field must be indexed without norms from the beginning.
		/// </para>
		/// </summary>
		/// <returns></returns>
		TResult WithoutNorms();
	}
}