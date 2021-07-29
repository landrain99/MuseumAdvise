using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ReviewDisplay
    {       
        public string UserName { get; set; }
        public string MuseumName { get; set; }
        public string Review { get; set; }
        public int Note { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}
