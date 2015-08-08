using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddAStringField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = "Bar";

			// Act
			document.Add(input).Store().As("Foo");

			// Assert
			var output = document.GetString("Foo");
			Assert.Equal(input, output);
		}

		[Fact]
		public void ThenIWantANonAnalyzedNoNormsFieldAdded()
		{
			// Arrange
			var document = new Document();

			// Act
			document.Add("Bar").Index().OmitNorms().As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.False(field.IsTokenized);
			Assert.True(field.OmitNorms);
		}

		[Fact]
		public void ThenIWantAnAnalyzedNoNormsFieldAdded()
		{
			// Arrange
			var document = new Document();

			// Act
			document.Add("Bar").Index().Analyze().OmitNorms().As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.True(field.OmitNorms);
		}

		[Fact]
		public void ThenIWantAnAnalyzedNormsFieldAdded()
		{
			// Arrange
			var document = new Document();

			// Act
			document.Add("Bar").Index().Analyze().As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.False(field.OmitNorms);
		}
	}
}