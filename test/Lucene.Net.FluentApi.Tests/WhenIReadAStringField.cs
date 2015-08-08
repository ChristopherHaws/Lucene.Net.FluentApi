using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests
{
	public class WhenIReadAStringField
	{
		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetString("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetStringOrNull("Foo");

			// Assert
			Assert.Null(value);
		}
	}
}
