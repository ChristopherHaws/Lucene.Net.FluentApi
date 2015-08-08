using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
    public class WhenIAddAnInt32Field
    {
		[Fact]
		public void ThenIWantItToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = Int32.MaxValue;

			// Act
			document.Add(input).Stored().As("Foo");

			// Assert
			var output = document.GetInt32("Foo");
			Assert.Equal(input, output);
		}

		[Fact]
		public void ThenIWantItToBeIndexed()
		{
			// Arrange
			var document = new Document();
			var input = Int32.MaxValue;

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
			var input = Int32.MaxValue;

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
			var input = Int32.MaxValue;
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
			var input = Int32.MaxValue;
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
