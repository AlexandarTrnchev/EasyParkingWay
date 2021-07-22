using Application.Common.Mappings;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Cities.Models
{
    public class CityDto : IMapFrom<City>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<Parking> Parkings { get; set; }
    }
}
