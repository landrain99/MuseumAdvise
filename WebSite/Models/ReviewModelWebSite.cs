using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class ReviewModelWebSite
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MuseumId { get; set; }
        public string Review { get; set; }
        public int Note { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}
