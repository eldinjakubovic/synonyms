using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synonyms.Models
{
    public class Words
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName ="int")]
        public int id1 { get; set; }
        [Column(TypeName = "nvarcha(50)")]
        public string name { get; set; }
    }
}
