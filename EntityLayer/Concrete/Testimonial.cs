using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        //REFERANSLAR
        [Key]
        public int TestimonialID { get; set; }

        [StringLength(200)]
        public string? Name { get; set; }

        [StringLength(150)]
        public string? SurName { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        [StringLength(150)]
        public string? Mail { get; set; }
    }
}
