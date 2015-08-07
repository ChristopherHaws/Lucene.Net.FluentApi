using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAnDoubleField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = Double.MaxValue;

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetDouble("Foo");
			Assert.Equal(input, output);
		}
	}
}