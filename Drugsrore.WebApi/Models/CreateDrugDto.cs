﻿using AutoMapper;
using Drugstore.Application.Drugs.Commands.CreateDrug;
using Drugstore.Application.Mapping;

namespace Drugsrore.WebApi.Models
{
    public class CreateDrugDto : IMapWith<CreateDrugCommand>
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDrugDto, CreateDrugCommand>();  
        }
    }
}
