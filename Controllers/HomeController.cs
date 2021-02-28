using CW.MoviesList.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CW.MoviesList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly string api_key = ConfigurationManager.AppSettings["TMD_API_KEY"];
        private readonly string api_auth_token = ConfigurationManager.AppSettings["TMD_API_AUTH_TOKEN"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> GetMoviesByName(string query, int page = 1)
        {
            SearchResult searchResult = new SearchResult();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {api_auth_token}");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync($"search/movie?api_key={api_key}&language=en-US&query={query}&page={page}");
                    if (Res.IsSuccessStatusCode)
                    { 
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        searchResult = JsonConvert.DeserializeObject<SearchResult>(Response);
                        searchResult.results = searchResult.results.Where(x => !string.IsNullOrEmpty(x.poster_path)).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                // Logging goes here
                throw;
            }
            return View(searchResult);
        }
        public async Task<ActionResult> GetMovieDetailsByID(int id)
        {
            MovieItem movieItem = new MovieItem();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                    client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {api_auth_token}");

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync($"movie/{id}?api_key={api_key}");
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        movieItem = JsonConvert.DeserializeObject<MovieItem>(Response);
                    }
                }
            }
            catch (Exception ex)
            {
                // Logging goes here
                throw;
            }
            return View(movieItem);
        }
    }
}