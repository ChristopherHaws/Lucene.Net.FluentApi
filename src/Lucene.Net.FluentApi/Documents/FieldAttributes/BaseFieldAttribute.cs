using System;

namespace Lucene.Net.Fluent.Documents.FieldAttributes
{
	public abstract class BaseFieldAttribute : Attribute
	{
		protected BaseFieldAttribute()
		{
			this.Store = true;
			this.Boost = 1.0f;
		}

		public String Name { get; set; }

		public Boolean Store { get; set; }

		public Single Boost { get; set; }
	}
}