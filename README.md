# Lucene.Net.FluentApi
![](https://spiralapps.visualstudio.com/DefaultCollection/_apis/public/build/definitions/5c966bbb-1fb5-42d3-a4ff-be9aecd6277b/3/badge)

Fluent API for Lucene.Net

Adding and Reading fields to and from a Document
------------------------------------------------------------

```c#
var document = new Document();

// String
document.Add("Foo").Stored().Indexed().Analyzed().As("MyString");
document.GetString("MyString");

// Int32
document.Add(Int32.MaxValue).Stored().Indexed().As("MyInt32");
document.GetInt32("MyInt32");

// Int64
document.Add(Int64.MaxValue).Stored().Indexed().As("MyInt64");
document.GetInt64("MyInt64");

// Single
document.Add(5.0f).Stored().Indexed().As("MySingle");
document.GetSingle("MySingle");

// Double
document.Add(5.0d).Stored().Indexed().As("MyDouble");
document.GetDouble("MyDouble");

// Boolean
document.Add(true).Stored().Indexed().As("MyBoolean");
document.GetBoolean("MyBoolean");

// DateTime
document.Add(DateTime.UtcNow).Stored().Indexed().As("MyDateTime");
document.GetDateTime("MyDateTime", DateTimeKind.Utc);
```