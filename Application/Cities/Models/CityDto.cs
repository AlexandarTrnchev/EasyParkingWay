using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Cities.Models
{
    public class CityDto : IMapFrom<City>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
