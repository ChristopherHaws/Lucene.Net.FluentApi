# Lucene.Net.FluentApi
![](https://spiralapps.visualstudio.com/DefaultCollection/_apis/public/build/definitions/5c966bbb-1fb5-42d3-a4ff-be9aecd6277b/3/badge)

Fluent API for Lucene.Net

Adding and Reading fields to and from a Document
------------------------------------------------------------

```c#
var document = new Document();

// String
document.Add("Foo").Store().Index().Analyze().OmitNorms().As("MyString");
document.GetString("MyString");

// Int32
document.Add(Int32.MaxValue).Store().Index().As("MyInt32");
document.GetInt32("MyInt32");

// Int64
document.Add(Int64.MaxValue).Store().Index().As("MyInt64");
document.GetInt64("MyInt64");

// Single
document.Add(Single.MaxValue).Store().Index().As("MySingle");
document.GetSingle("MySingle");

// Double
document.Add(Double.MaxValue).Store().Index().As("MyDouble");
document.GetDouble("MyDouble");

// Boolean
document.Add(true).Store().Index().As("MyBoolean");
document.GetBoolean("MyBoolean");

// DateTime
document.Add(DateTime.UtcNow).Store().Index().As("MyDateTime");
document.GetDateTime("MyDateTime", DateTimeKind.Utc);
```