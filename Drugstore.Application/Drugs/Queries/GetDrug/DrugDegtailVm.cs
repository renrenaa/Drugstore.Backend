using AutoMapper;
using Drugstore.Application.Mapping;
using Drugstore.Domain;

namespace Drugstore.Application.Drugs.Queries.GetDrug
{
    public class DrugDegtailVm : IMapWith<Drug>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Drug, DrugDegtailVm>();
        }
    }
}
