

using BLL.DTOs;
using WebUi.Models;

namespace WebUi
{
    public class AutoMapperProfileWebUi : Profile
    {
        public AutoMapperProfileWebUi()
        {
            CreateMap<DrugDto, DrugViewModel>().ReverseMap();

        }
    }
}
