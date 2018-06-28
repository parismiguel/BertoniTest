using System;
using System.Collections.Generic;
using System.Text;

namespace BertoniTest.Library.Models
{

    public class VuetableResponse
    {
        public int Total { get; set; }
        public int Per_page { get; set; }
        public int Current_page { get; set; }
        public int Last_page { get; set; }
        public string Next_page_url { get; set; }
        public object Prev_page_url { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public Object[] Data { get; set; }
    }

   
}
