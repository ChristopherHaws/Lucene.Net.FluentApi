# Lucene.Net.FluentApi
![](https://spiralapps.visualstudio.com/DefaultCollection/_apis/public/build/definitions/5c966bbb-1fb5-42d3-a4ff-be9aecd6277b/3/badge)

Fluent API for Lucene.Net

Adding and Reading fields to and from a Document
------------------------------------------------------------
```c#
var document = new Document();

// String
document.Add("Foo").Stored().Indexed().Analyzed().As("StringField");
document.GetString("StringField");

// Int32
document.Add(Int32.MaxValue).Stored().Indexed().As("Int32Field");
document.GetInt32("Int32Field");

// Int64
document.Add(Int64.MaxValue).Stored().Indexed().As("Int64Field");
document.GetInt64("Int64Field");

// Single
document.Add(5.0f).Stored().Indexed().As("SingleField");
document.GetSingle("SingleField");

// Double
document.Add(5.0d).Stored().Indexed().As("DoubleField");
document.GetDouble("DoubleField");

// Boolean
document.Add(true).Stored().Indexed().As("BooleanField");
document.GetBoolean("BooleanField");

// DateTime
document.Add(DateTime.UtcNow).Stored().Indexed().As("DateTimeField");
document.GetDateTime("DateTimeField", DateTimeKind.Utc);

// Boosted String
document.Add("Foo").Stored().Indexed().Analyzed().BoostBy(5.0f).As("BoostedStringField");
document.GetString("BoostedStringField");
```


Adding and Reading fields via FieldAttribute and NumericFieldAttribute
------------------------------------------------------------
```c#
void Main()
{
	var document = new Document();

	var data = new ClassWithFieldAttributes
	{
		StringField = "Foo",
		Int32Field = Int32.MaxValue,
		Int64Field = Int64.MaxValue,
		SingleField = 5.0f,
		DoubleField = 5.0d,
		BooleanField = true,
		DateTimeField = DateTime.UtcNow,
		BoostedStringField = "Foo",
	};

	document.AddFields(data);

	document.GetString("StringField");
	document.GetInt32("Int32Field");
	document.GetInt64("Int64Field");
	document.GetSingle("SingleField");
	document.GetDouble("DoubleField");
	document.GetBoolean("BooleanField");
	document.GetDateTime("DateTimeField", DateTimeKind.Utc);
	document.GetString("MyBoostedString");
}

public class ClassWithFieldAttributes
{
	[Field(IndexMode = IndexMode.Analyzed, Store = true)]
	public String StringField { get; set; }

	[NumericField(Index = true, Store = true)]
	public Int32 Int32Field { get; set; }

	[NumericField(Index = true, Store = true)]
	public Int64 Int64Field { get; set; }

	[NumericField(Index = true, Store = true)]
	public Single SingleField { get; set; }

	[NumericField(Index = true, Store = true)]
	public Double DoubleField { get; set; }

	[NumericField(Index = true, Store = true)]
	public Boolean BooleanField { get; set; }

	[NumericField(Index = true, Store = true)]
	public DateTime DateTimeField { get; set; }

	[NumericField(Index = true, Store = true, Boost = 5.0d)]
	public String BoostedStringField { get; set; }
}
```