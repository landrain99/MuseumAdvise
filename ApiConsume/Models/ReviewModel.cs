using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MuseumId { get; set; }
        public string Review { get; set; }
        public int Note { get; set; }
        /// <summary>
        /// Creation date of the review
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; } 
        public int Price { get; set; }
    }
}
