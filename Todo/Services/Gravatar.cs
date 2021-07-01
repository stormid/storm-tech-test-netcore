
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Todo.Services
{
    public static class Gravatar
    {
        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }

        public static async Task<string> GetProfileName(string emailAddress)
        {
            HttpClient client = new HttpClient();

            var hash = GetHash(emailAddress);
            var url = $"https://www.gravatar.com/{hash}.json"; //json url
            var hasAccountUrl = $"https://www.gravatar.com/avatar/{hash}?d=404";

            var cts = new CancellationTokenSource();

            //lets impersonate browser headers.
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

            try
            {
                HttpResponseMessage hasAccount = await client.GetAsync(hasAccountUrl, cts.Token);

                //if we have a 404 then the email address is not asscioted to a gravatar account.
                if (hasAccount.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return "";

                HttpResponseMessage response = await client.GetAsync(url, cts.Token);
                response.EnsureSuccessStatusCode();
                
                var responseBody = await response.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<Root>(responseBody);

                var name = json?.Entry?.Select(s => s.Name.Formatted).FirstOrDefault();

                return !string.IsNullOrEmpty(name) ? $" - {name}" : "";
            }
            catch (TaskCanceledException ex)
            {
                //If the api call timeouts, catch it and display an error instead of a username so we know something has gone wrong.
                Console.WriteLine(ex.InnerException);
                return "API - ERROR (please contact support)";
            }
        }

        #region model

        public class Name
        {
            [JsonProperty("givenName")]
            public string GivenName { get; set; }

            [JsonProperty("familyName")]
            public string FamilyName { get; set; }

            [JsonProperty("formatted")]
            public string Formatted { get; set; }
        }

        public class Entry
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("requestHash")]
            public string RequestHash { get; set; }

            [JsonProperty("profileUrl")]
            public string ProfileUrl { get; set; }

            [JsonProperty("preferredUsername")]
            public string PreferredUsername { get; set; }

            [JsonProperty("thumbnailUrl")]
            public string ThumbnailUrl { get; set; }

            [JsonProperty("photos")]
            public List<object> Photos { get; set; }

            [JsonProperty("name")]
            public Name Name { get; set; }

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }

            [JsonProperty("currentLocation")]
            public string CurrentLocation { get; set; }

            [JsonProperty("urls")]
            public List<object> Urls { get; set; }
        }

        public class Root
        {
            [JsonProperty("entry")]
            public List<Entry> Entry { get; set; }
        }
        #endregion

    }
}