using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Domain
{
    internal class Drug
    {
        public Guid Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }

    }
}
