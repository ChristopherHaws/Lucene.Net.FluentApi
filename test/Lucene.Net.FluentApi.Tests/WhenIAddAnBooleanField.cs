using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAnBooleanField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = true;

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetBoolean("Foo");
			Assert.Equal(input, output);
		}
	}
}