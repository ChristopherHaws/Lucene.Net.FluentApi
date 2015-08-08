using System;
using Lucene.Net.Documents;
using Xunit;

namespace Lucene.Net.FluentApi.Tests
{
    public class WhenIAddASerializedObject
    {
		[Fact]
		public void ThenIWantItToBeStored()
		{
			// Arrange
			var document = new Document();
			var input = new SerializeableObject
			{
				Foo = "Bar"
			};

			// Act
			document.Add(input).As("Foo");

			// Assert
			var output = document.GetSerializedObject<SerializeableObject>("Foo");
			Assert.Equal(input.Foo, output.Foo);
		}

		[Fact]
		public void ThenIWantItToBeStoredWithCompression()
		{
			// Arrange
			var document = new Document();
			var input = new SerializeableObject
			{
				Foo = "Bar"
			};

			// Act
			document.Add(input).WithCompression().As("Foo");

			// Assert
			var output = document.GetSerializedObjectWithCompression<SerializeableObject>("Foo");
			Assert.Equal(input.Foo, output.Foo);
		}
	}

	[Serializable]
	public class SerializeableObject
	{
		public String Foo { get; set; }
	}
}
