using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Experience
    {
        // İŞ DENEYİMLERİ
        [Key]
        public int ExperienceID { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }

        [StringLength(250)]
        public string? Position { get; set; }

        [StringLength(600)]
        public string? Description { get; set; }        

        [StringLength(50)]
        public string? StartDate { get; set; }

        [StringLength(50)]
        public string? FinishDate { get; set; }
    }
}
