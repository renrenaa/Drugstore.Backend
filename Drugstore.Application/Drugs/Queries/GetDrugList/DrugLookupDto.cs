using AutoMapper;
using Drugstore.Application.Mapping;
using Drugstore.Domain;

namespace Drugstore.Application.Drugs.Queries.GetDrugList
{
    public class DrugLookupDto : IMapWith<Drug>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Tittle { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Drug, DrugLookupDto>()
                .ForMember(drugDto => drugDto.Id,
                    opt => opt.MapFrom(drug => drug.Id))
                .ForMember(drugDto => drugDto.Price,
                    opt => opt.MapFrom(drug => drug.Price))
                .ForMember(drugDto => drugDto.Tittle,
                    opt => opt.MapFrom(drug => drug.Tittle));
        }
    }
}