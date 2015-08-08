using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.Fluent.FluentApi.Tests.AddFields
{
	public class WhenIAddASingleField
	{
		[Fact]
		public void ThenIWantItToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = 5f;

			// Act
			document.Add(input).Stored().As("Foo");

			// Assert
			var output = document.GetSingle("Foo");
			Assert.Equal(input, output);
		}

		[Fact]
		public void ThenIWantItToBeIndexed()
		{
			// Arrange
			var document = new Document();
			var input = 5f;

			// Act
			document.Add(input).Indexed().As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
		}

		[Fact]
		public void ThenIWantItToBeIndexedWithPrecisionStep()
		{
			// Arrange
			var document = new Document();
			var input = 5f;

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
			var input = 5f;
			var boost = 2.0f;

			// Act
			document.Add(input).Indexed().BoostBy(boost).As("Foo");

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
			var input = 5f;
			var boost = 2.0f;

			// Act
			document.Add(input).Indexed().WithPrecisionStep(8).BoostBy(boost).As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
			Assert.Equal(boost, field.Boost);
		}
	}
}