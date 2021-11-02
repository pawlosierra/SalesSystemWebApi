using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesSystem.DTOs;
using SalesSystem.Models;

namespace SalesSystem.DTOs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClientDTO,Client>();
            CreateMap<Client,ClientDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            //CreateMap<SaleDTO, Sale>().ForMember(dest => dest.Concepts, opt => opt.Ignore());
            CreateMap<SaleDTO, Sale>().ForMember(dest => dest.Concepts, opt => opt.MapFrom(src => src.Concepts));
            //CreateMap<Sale, SaleDTO>().ForMember(dest => dest.Concepts, opt => opt.MapFrom(src => src.Concepts));
            CreateMap<Sale, SaleDTO>();

            CreateMap<ConceptDTO, Concept>();
            CreateMap<Concept, ConceptDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

        }
    }
}
