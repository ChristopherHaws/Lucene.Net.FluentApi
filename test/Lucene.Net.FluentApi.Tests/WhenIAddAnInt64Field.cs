using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAnInt64Field
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = Int64.MaxValue;

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetInt64("Foo");
			Assert.Equal(input, output);
		}
	}
}