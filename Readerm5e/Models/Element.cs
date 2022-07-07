using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerm5e.Models
{
    class Element
    {
        public int Id { get; set; }
        public string EPC { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }

        public string Status { get; set; }

    }
}
