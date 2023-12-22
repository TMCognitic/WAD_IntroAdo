using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnexionDb.Entities
{
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int? DelegateId { get; set; }
    }
}
