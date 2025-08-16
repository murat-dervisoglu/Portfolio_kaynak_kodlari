using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skills
    {
        //DİLLER
        [Key]
        public int SkillID { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }
    }
}
