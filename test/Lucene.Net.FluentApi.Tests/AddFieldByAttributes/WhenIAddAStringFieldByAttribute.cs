using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldAttributes;
using Xunit;

namespace Lucene.Net.FluentApi.Tests.AddFieldByAttributes
{
    public class WhenIAddAStringFieldByAttribute
    {
	    [Fact]
	    public void Bar()
	    {
		    // Arrange
			var document = new Document();
			var foo = new ClassWithFieldAttributes
			{
				FieldOne = "Test",
				FieldTwo = "Test2"
			};

			// Act
			document.AddFields(foo);

			// Assert
			Assert.Equal(foo.FieldOne, document.GetString("FieldOne"));
			Assert.Equal(foo.FieldTwo, document.GetString("FieldTwo"));
		}
    }


	public class ClassWithFieldAttributes
	{
		[Field(IndexMode = IndexMode.Analyzed, Store = true)]
		public String FieldOne { get; set; }

		[Field(IndexMode = IndexMode.Analyzed, Store = true)]
		public String FieldTwo { get; set; }
	}
}
