using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Education
    {
        //EĞİTİM
        [Key]
        public int EducationID { get; set; }

        [StringLength(300)]
        public string? School { get; set; }

        [StringLength(300)]
        public string? Section { get; set; }

        [StringLength(600)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? StartDate { get; set; }

        [StringLength(50)]
        public string? FinishDate { get; set; }
    }
}
