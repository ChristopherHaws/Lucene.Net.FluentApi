using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
    public class WhenIAddAStoredFieldToADocument
    {
		[Fact]
	    public void ThenIWantStringFieldsToBeStored()
	    {
			// Arrange
			var document = new Document();
			var value = "Bar";

			// Act
			document.AddField("Foo").Stored().Value(value);

			// Assert
			Assert.Equal(value, document.GetString("Foo"));
	    }

		[Fact]
		public void ThenIWantInt32FieldsToBeStored()
		{
			// Arrange
			var document = new Document();
			var value = 5;

			// Act
			document.AddField("Foo").Stored().Value(value);

			// Assert
			Assert.Equal(value, document.GetInt32("Foo"));
		}

		[Fact]
		public void ThenIWantDateTimeFieldsToBeStored()
		{
			// Arrange
			var document = new Document();
			var value = DateTime.UtcNow;

			// Act
			document.AddField("Foo").Stored().Value(value);

			// Assert
			Assert.Equal(value, document.GetDateTime("Foo", DateTimeKind.Utc));
		}

		[Fact]
		public void ThenIWantBooleanFieldsToBeStored()
		{
			// Arrange
			var document = new Document();
			var value = true;

			// Act
			document.AddField("Foo").Stored().Value(value);

			// Assert
			Assert.Equal(value, document.GetBoolean("Foo"));
		}
	}
}
