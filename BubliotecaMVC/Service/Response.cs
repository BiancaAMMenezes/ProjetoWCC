using System.Collections.Generic;

namespace BibliotecaMVC.Service
{
    public class Response
    {
        int resultCount { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string trackName { get; set; }
        public string artistName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string[] genres { get; set; }
        public string artworkUrl60 { get; set; }
        public int trackid { get; set; }


    }
}
