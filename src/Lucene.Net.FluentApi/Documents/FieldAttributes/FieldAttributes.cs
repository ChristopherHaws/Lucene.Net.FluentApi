using System;
using Lucene.Net.Documents;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class FieldAttribute : Attribute
	{
	    public FieldAttribute()
	    {
			this.Store = true;
			this.Boost = 1.0f;
		}

		public IndexMode IndexMode { get; set; }

		public Boolean Store { get; set; }

		public Single Boost { get; set; }

		public Type Analyzer { get; set; }
	}

	public enum IndexMode
	{
		/// <summary>
		/// Disables indexing tokens.
		/// </summary>
		NotIndexed = Field.Index.NO,

		/// <summary>
		/// Index the tokens produced by running the field's value through an Analyzer. This is useful for common text.
		/// </summary>
		Analyzed = Field.Index.ANALYZED,

		/// <summary>
		/// Index the tokens produced by running the field's value through an Analyzer without storing norms. This is useful for common text.
		/// <para>No norms means that index-time field and document boosting and field length normalization are disabled.</para>
		/// <para>The benefit is less memory usage as norms take up one byte of RAM per indexed field for every document in the index, during searching.</para>
		/// <para>
		/// Note that once you index a given field with norms enabled, disabling norms will have no effect. In other words, for this to have the
		/// above described effect on a field, all instances of that field must be indexed without norms from the beginning.
		/// </para>
		/// </summary>
		AnalyzedNoNorms = Field.Index.ANALYZED_NO_NORMS,


		/// <summary>
		/// Index the field's value so it can be searched. The value will be stored as a single term. This is useful for unique Ids like product numbers.
		/// </summary>
		NotAnalyzed = Field.Index.NOT_ANALYZED,

		/// <summary>
		/// Disable the storing of norms. 
		/// <para>No norms means that index-time field and document boosting and field length normalization are disabled.</para>
		/// <para>The benefit is less memory usage as norms take up one byte of RAM per indexed field for every document in the index, during searching.</para>
		/// <para>
		/// Note that once you index a given field with norms enabled, disabling norms will have no effect. In other words, for this to have the
		/// above described effect on a field, all instances of that field must be indexed without norms from the beginning.
		/// </para>
		/// </summary>
		NotAnalyzedNoNorms = Field.Index.NOT_ANALYZED_NO_NORMS,
	}
}
