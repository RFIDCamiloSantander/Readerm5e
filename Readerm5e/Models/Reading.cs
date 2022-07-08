using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerm5e.Models
{
    class Reading
    {
        public int Id { get; set; }

        public long TimeStamp { get; set; }

        public int ElementoId { get; set; }

        public string ElementoName { get; set; }

        public string ElementoDescription { get; set; }
    }
}