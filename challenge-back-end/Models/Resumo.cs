using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge_back_end.Models
{
    public class Resumo
    {
        public int TotalLikes { get; set; }
        public int totalViews { get; set; }
        public List<Posts> ListaPosts { get; set; }
    }
}