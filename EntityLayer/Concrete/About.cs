using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        //HAKKIMDA
        [Key]
        public int AboutID { get; set; }

        [StringLength(600)]
        public string? Description { get; set; } 

        public DateOnly? BirthDate { get; set; }

        [StringLength(200)]
        public string? Mail { get; set; } = "-";

        [StringLength(50)]
        public string? Phone { get; set; } = "-";

        [StringLength(350)]
        public string? Address { get; set; } 
    }
}
