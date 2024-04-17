using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entites;

namespace Talabat.APIs.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
        {

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(D => D.Brand, O => O.MapFrom(S => S.Brand.Name))
                .ForMember(D => D.Category, O => O.MapFrom(S => S.Category.Name))
                //.ForMember(d => d.PictureUrl, o => o.MapFrom(s => $"{"https://localhost:7054"}/{s.PictureUrl}"));
                .ForMember(D => D.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());
		}
    }
}
