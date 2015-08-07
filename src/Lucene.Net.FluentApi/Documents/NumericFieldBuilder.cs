using System;

namespace Lucene.Net.Documents
{
	public abstract class NumericFieldBuilder<T>
	{
		protected readonly Document Document;
		protected readonly T Value;
		private Boolean store;
		private Boolean index;

		protected NumericFieldBuilder(Document document, T value)
		{
			this.Document = document;
			this.Value = value;
		}

		public NumericFieldBuilder<T> Store()
		{
			this.store = true;
			return this;
		}

		public NumericFieldBuilder<T> Index()
		{
			this.index = true;
			return this;
		}

		public abstract void As(String name);

		protected NumericField BuildField(String name)
		{
			return new NumericField(name, this.store ? Field.Store.YES : Field.Store.NO, this.index);
		} 
	}
}