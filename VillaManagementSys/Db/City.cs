using System;
using System.Collections.Generic;

namespace VillaManagementSys.Db
{
    public partial class City
    {
        public City()
        {
            Villas = new HashSet<Villa>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PrefixCode { get; set; }
        public decimal? Longtitude { get; set; }
        public decimal? Latitude { get; set; }
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<Villa> Villas { get; set; }
    }
}
