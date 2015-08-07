using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAnDateTimeField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = DateTime.UtcNow;

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetDateTime("Foo", DateTimeKind.Utc);
			Assert.Equal(input, output);
		}
	}
}