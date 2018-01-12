using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SaAPI.Context
{
    public class ResourcePath
    {
        public string ApiVersion { get; }

        public string Path { get; set; }

        public IList<string> QueryList { get; set; }

        public static string[] AvailableApiVersions =
        {
            "2017-06-15-Int"
        };

        private static readonly Regex UrlFormatRegex = new Regex(@"^/api/(?<Service>[a-zA-Z0-9]{1,50})(/|\?|$)(.*)", RegexOptions.Compiled);

        public ResourcePath(Uri uri)
        {
            var match = UrlFormatRegex.Match(uri.PathAndQuery);

            var uriQuery = uri.Query;
            if (!string.IsNullOrWhiteSpace(uriQuery))
            {
                QueryList =
                    uri.Query.Substring(1)
                        .Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries)
                        .OrderBy(x => x)
                        .ToList();
            }

            var query = HttpUtility.ParseQueryString(uriQuery);
            if (query.AllKeys.Any(key => "api-version".Equals(key)))
            {
                ApiVersion = query.GetValues("api-version")?.FirstOrDefault();
            }

            Path = uri.AbsolutePath;
        }
    }
}