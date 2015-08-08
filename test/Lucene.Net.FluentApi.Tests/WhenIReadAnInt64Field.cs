using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests
{
	public class WhenIReadAnInt64Field
	{

		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetInt64("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetInt64OrNull("Foo");

			// Assert
			Assert.Null(value);
		}
	}
}