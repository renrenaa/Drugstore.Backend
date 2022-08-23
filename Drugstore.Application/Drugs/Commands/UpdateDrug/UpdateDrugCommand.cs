using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugstore.Application.Drugs.Commands.UpdateDrug
{
    public class UpdateDrugCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }
    }
}
