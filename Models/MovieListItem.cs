using System;
using System.Collections.Generic;

namespace CW.MoviesList.Web.Models
{
    public class MovieListItem
    {
        public int id { set; get; }
        public int page { set; get; }
        public int total_pages { set; get; }
        public int total_results { set; get; }
        public int runtime { set; get; }
        public string description { set; get; }
        public Dictionary<string, string> object_ids { set; get; }
        public string name { set; get; }
        public string poster_path { set; get; }
        //public List<MovieItem> results { set; get; }
        public bool @public { set; get; }

    }
    public class MovieItem
    {
        public int id { set; get; }
        public int runtime { set; get; }
        public string title { set; get; }
        public string original_title { set; get; }
        public string tagline { set; get; }
        public string overview { set; get; }
        public string homepage { set; get; }
        public string release_date { set; get; }
        public decimal vote_average { set; get; }
        public decimal popularity { set; get; }
        public int vote_count { set; get; }
        public Int64 budget { set; get; }
        public Int64 revenue { set; get; }
        public string budget_string { set; get; }
        public string poster_path { set; get; }
        public bool adult { set; get; }
        public List<int> genre_ids { set; get; }
        public List<ProductionCompany> production_companies { set; get; }
    }
    public class SearchResult
    {
        public int page { set; get; }
        public int total_pages { set; get; }
        public int total_results { set; get; }
        public List<MovieItem> results { set; get; }
    }
    public class ProductionCompany
    {
        public int id { set; get; }
        public string name { set; get; }

    }
}