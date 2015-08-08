using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests
{
	public class WhenIReadADateTimeField
	{

		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetDateTime("Foo", DateTimeKind.Unspecified));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetDateTimeOrNull("Foo", DateTimeKind.Unspecified);

			// Assert
			Assert.Null(value);
		}
	}
}