using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
	public class WhenIReadASerializedObject
	{
		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetSerializedObject<SerializeableObject>("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStored()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetSerializedObjectOrNull<SerializeableObject>("Foo");

			// Assert
			Assert.Null(value);
		}
		[Fact]
		public void ThenIWantAnErrorWhenTheValueIsNotStoredWithCompression()
		{
			// Arrange
			var document = new Document();

			// Act

			// Assert
			Assert.Throws<InvalidOperationException>(() => document.GetSerializedObjectWithCompression<SerializeableObject>("Foo"));
		}

		[Fact]
		public void ThenIWantNullWhenTheValueIsNotStoredWithCompression()
		{
			// Arrange
			var document = new Document();

			// Act
			var value = document.GetSerializedObjectWithCompressionOrNull<SerializeableObject>("Foo");

			// Assert
			Assert.Null(value);
		}
	}
}