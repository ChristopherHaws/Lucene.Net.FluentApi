using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIAddADateTimeField
	{
		[Fact]
		public void ThenIWantTheFieldToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = DateTime.UtcNow;

			// Act
			document.Add(input).Stored().As("Foo");

			// Assert
			var output = document.GetDateTime("Foo", DateTimeKind.Utc);
			Assert.Equal(input, output);
		}

		[Fact]
		public void ThenIWantTheFieldToBeIndexed()
		{
			// Arrange
			var document = new Document();
			var input = DateTime.UtcNow;

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
			var input = DateTime.UtcNow;

			// Act
			document.Add(input).Indexed().WithPrecisionStep(8).As("Foo");

			// Assert
			var field = document.GetFieldable("Foo");
			Assert.True(field.IsIndexed);
		}
	}
}