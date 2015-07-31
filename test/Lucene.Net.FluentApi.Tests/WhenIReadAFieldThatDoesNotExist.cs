using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIReadAFieldThatDoesNotExist
	{
		[Fact]
		public void ThenIWantStringToThrow()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetString("Foo"));
		}

		[Fact]
		public void ThenIWantStringOrNullToBeNull()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetStringOrNull("Foo");

			// Assert
			Assert.Null(value);
		}

		[Fact]
		public void ThenIWantInt32ToThrow()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetInt32("Foo"));
		}

		[Fact]
		public void ThenIWantInt32OrNullToBeNull()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetInt32OrNull("Foo");

			// Assert
			Assert.Null(value);
		}

		[Fact]
		public void ThenIWantInt64ToThrow()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetInt64("Foo"));
		}

		[Fact]
		public void ThenIWantInt64OrNullToBeNull()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetInt64OrNull("Foo");

			// Assert
			Assert.Null(value);
		}

		[Fact]
		public void ThenIWantBooleanToThrow()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetBoolean("Foo"));
		}

		[Fact]
		public void ThenIWantBooleanOrNullToBeNull()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetBooleanOrNull("Foo");

			// Assert
			Assert.Null(value);
		}

		[Fact]
		public void ThenIWantDateTimeToThrow()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetDateTime("Foo", DateTimeKind.Unspecified));
		}

		[Fact]
		public void ThenIWantDateTimeOrNullToBeNull()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetDateTimeOrNull("Foo", DateTimeKind.Unspecified);

			// Assert
			Assert.Null(value);
		}
	}
}
