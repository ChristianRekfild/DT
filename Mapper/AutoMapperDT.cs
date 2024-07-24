using AutoMapper;
using DT.Model.Data.Location;
using DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT.Mapper
{
    public class AutoMapperDT : Profile
    {
        public AutoMapperDT()
        {
            //CreateMap<List<Region>, List<RegionDTO>>()
            //    .ForMember(
            //        dest => dest.,
            //        opt => opt.MapFrom(src => src.LibraryItemCategories));

            CreateMap<Region, RegionDTO>()
                .ForMember(x => x.Cities, c => c.MapFrom(v => v.Cities));
            CreateMap<RegionDTO, Region>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            //.ForMember(s => s.PageUIs, c => c.MapFrom(m => m.Pages));
            //Mapper.CreateMap<Page, PageUI>();
        }
    }
}
