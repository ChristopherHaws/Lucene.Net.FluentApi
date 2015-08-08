using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIReadABooleanField
	{

		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetBoolean("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetBooleanOrNull("Foo");

			// Assert
			Assert.Null(value);
		}
	}
}