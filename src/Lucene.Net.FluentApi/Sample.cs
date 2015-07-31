using System;
using Lucene.Net.Documents;

namespace Lucene.Net
{
	public class Sample
	{
		public void Run()
		{
			var document = new Document();

			document.AddField("Foo").Stored().Indexed().Value("Bar");
			document.AddField("FooBool").Stored().Indexed().Value(true);
			document.AddField("ModifiedOn").Stored().Indexed().Value(DateTime.UtcNow);

			document.GetBooleanOrNull("FooBool");
			document.GetDateTime("ModifiedOn", DateTimeKind.Utc);
		}
	}
}
