using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddASingleField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;

			// Act
			document.Add(input).Stored().As("Foo");

			// Assert
			var output = document.GetSingle("Foo");
			Assert.Equal(input, output);
		}

		[Fact]
		public void ThenIWantTheFieldToBeIndexed()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;

			// Act
			document.Add(input).Indexed().As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
		}

		[Fact]
		public void ThenIWantTheFieldToBeIndexedWithPrecisionStep()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;

			// Act
			document.Add(input).Indexed().WithPrecisionStep(8).As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
		}

		[Fact]
		public void ThenIWantItToBeIndexedWithBoost()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;
			var boost = 2.0f;

			// Act
			document.Add(input).Indexed().Boost(boost).As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
			Assert.Equal(boost, field.Boost);
		}

		[Fact]
		public void ThenIWantItToBeIndexedWithPrecisionStepWithBoost()
		{
			// Arrange
			var document = new Document();
			var input = 50156.60f;
			var boost = 2.0f;

			// Act
			document.Add(input).Indexed().WithPrecisionStep(8).Boost(boost).As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
			Assert.Equal(boost, field.Boost);
		}
	}
}