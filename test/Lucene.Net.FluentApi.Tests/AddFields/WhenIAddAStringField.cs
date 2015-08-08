using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests.AddFields
{
	public class WhenIAddAStringField
	{
		[Fact]
		public void ThenIWantItToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = "Bar";

			// Act
			document.Add(input).Stored().As("Foo");

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
			document.Add("Bar").Indexed().WithoutNorms().As("Foo");

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
			document.Add("Bar").Indexed().Analyzed().WithoutNorms().As("Foo");

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
			document.Add("Bar").Indexed().Analyzed().As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.False(field.OmitNorms);
		}

		[Fact]
		public void ThenIWantItToBeIndexedAndBoosted()
		{
			// Arrange
			var document = new Document();
			var boost = 2.0f;

			// Act
			document.Add("Bar").Indexed().BoostBy(boost).As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.False(field.IsTokenized);
			Assert.False(field.OmitNorms);
			Assert.Equal(boost, field.Boost);
		}

		[Fact]
		public void ThenIWantItToBeIndexedAndNotAnalyzedWithoutNormsAndBoosted()
		{
			// Arrange
			var document = new Document();
			var boost = 2.0f;

			// Act
			document.Add("Bar").Indexed().WithoutNorms().BoostBy(boost).As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.False(field.IsTokenized);
			Assert.True(field.OmitNorms);
			Assert.Equal(boost, field.Boost);
		}

		[Fact]
		public void ThenIWantItToBeIndexedAndAnalyzedAndBoosted()
		{
			// Arrange
			var document = new Document();
			var boost = 2.0f;

			// Act
			document.Add("Bar").Indexed().Analyzed().BoostBy(boost).As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.False(field.OmitNorms);
			Assert.Equal(boost, field.Boost);
		}

		[Fact]
		public void ThenIWantItToBeIndexedAndAnalyzedWithoutNormsAndBoosted()
		{
			// Arrange
			var document = new Document();
			var boost = 2.0f;

			// Act
			document.Add("Bar").Indexed().Analyzed().WithoutNorms().BoostBy(boost).As("Foo");

			// Assert
			var field = document.GetField("Foo");
			Assert.True(field.IsIndexed);
			Assert.True(field.IsTokenized);
			Assert.True(field.OmitNorms);
			Assert.Equal(boost, field.Boost);
		}
	}
}