using AutoMapper;
using Drugstore.Application.Mapping;
using Drugstore.Domain;

namespace Drugstore.Application.Drugs.Queries.GetDrug
{
    public class DrugDegtailVm : IMapWith<Drug>
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Drug, DrugDegtailVm>()
        //        .ForMember(drugVm => drugVm.Id,
        //            opt => opt.MapFrom(drug => drug.Id))
        //        .ForMember(drugVm => drugVm.Price,
        //            opt => opt.MapFrom(drug => drug.Price))
        //        .ForMember(drugVm => drugVm.Tittle,
        //            opt => opt.MapFrom(drug => drug.Tittle))
        //        .ForMember(drugVm => drugVm.Quantity,
        //            opt => opt.MapFrom(drug => drug.Quantity))
        //        .ForMember(drugVm => drugVm.Description,
        //            opt => opt.MapFrom(drug => drug.Description))
        //        .ForMember(drugVm => drugVm.IsOnPrescription,
        //            opt => opt.MapFrom(drug => drug.IsOnPrescription));
        //}
    }
}
