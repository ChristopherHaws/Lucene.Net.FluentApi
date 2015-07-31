using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
    public class WhenIAddAnIndexedField
    {
		[Fact]
		public void ThenIWantANonAnalyzedNoNormsFieldAdded()
		{
			// Arrange
			var document = new Document();

			// Act
			document.AddField("Foo").Indexed().Value("Bar");

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
			document.AddField("Foo").Indexed(true).Value("Bar");

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
			document.AddField("Foo").Indexed(true, true).Value("Bar");

			// Assert
			var field = document.GetField("Foo");
            Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.False(field.OmitNorms);
		}
	}
}
