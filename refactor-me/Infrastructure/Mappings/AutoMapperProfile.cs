using AutoMapper;
using RefactionMe.Api.Models;
using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactionMe.Api.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductOption, ProductOptionViewModel>();
            CreateMap<ProductOptionViewModel, ProductOption>();
        }


        public override string ProfileName
        {
            get
            {
                return "RefactionMeMapper";
            }
        }









    }
}