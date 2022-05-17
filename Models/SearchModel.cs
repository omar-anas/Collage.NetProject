using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imdb.Models
{
    public class SearchModel
    {
        public  List<movie> movies { get; set; }
        public List<actor> actors { get; set; }
        public List<director> directors { get; set; }
    }
}