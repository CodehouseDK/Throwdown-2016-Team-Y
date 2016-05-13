using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

namespace TeamY.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                string result = await client.GetStringAsync("repos/CodehouseDK/Throwdown-2016-Team-Y/commits?per_page=1000");
                var commits = JsonConvert.DeserializeObject<IList<Commit>>(result);

                var list = commits
                    .Select(x => x.CommitInfo.Author.Email).Distinct()
                    .Select(email => new
                    {
                        Email = email,
                        Count = commits.Count(x => x.CommitInfo.Author.Email == email)
                    }).ToList();

                return Ok(list);
            }
        }
    }

    public class Commit
    {
        public string Sha { get; set; }

        [JsonProperty("Commit")]
        public CommitInfo CommitInfo { get; set; }
    }

    public class CommitInfo
    {
        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}