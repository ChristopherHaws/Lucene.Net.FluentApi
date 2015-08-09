using System;
using Lucene.Net.Documents;
using Lucene.Net.Fluent.Documents.FieldAttributes;
using Lucene.Net.Fluent.Documents.Types;
using Xunit;

namespace Lucene.Net.FluentApi.Tests.AddFieldByAttributes
{
    public class WhenIAddAStringFieldByAttribute
    {
	    [Fact]
	    public void ThenIWantItToBeStored()
	    {
		    // Arrange
			var document = new Document();
			var value = new ClassWithFieldAttributes
			{
				FieldOne = "Test",
				FieldTwo = "Test2"
			};

			// Act
			document.AddFields(value);

			// Assert
			Assert.Equal(value.FieldOne, document.GetString("FieldOne"));
			Assert.Equal(value.FieldTwo, document.GetString("FieldTwo"));
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
