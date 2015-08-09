using System;
using Lucene.Net.Fluent.Documents.Types;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class FieldAttribute : BaseFieldAttribute
	{
		public IndexMode IndexMode { get; set; }

		public TermVectorMode TermVector { get; set; }

		public Type Analyzer { get; set; }
	}
}
