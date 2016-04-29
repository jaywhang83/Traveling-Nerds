using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Traveling_Nerds.Models
{
    [Table("Locations")]
    public class Location
    {
        public Location()
        {
            this.Postings = new HashSet<Posting>();
        }
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Posting> Postings { get; set; }
    }
}
