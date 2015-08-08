using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests
{
	public class WhenIReadAnInt32Field
	{

		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetInt32("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetInt32OrNull("Foo");

			// Assert
			Assert.Null(value);
		}
	}
}