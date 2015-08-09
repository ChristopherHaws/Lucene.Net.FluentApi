using System;
using Lucene.Net.Fluent.Documents.Types;

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
}
