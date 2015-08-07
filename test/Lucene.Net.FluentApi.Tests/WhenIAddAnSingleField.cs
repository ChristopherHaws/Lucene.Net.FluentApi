using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAnSingleField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetSingle("Foo");
			Assert.Equal(input, output);
		}
	}
}