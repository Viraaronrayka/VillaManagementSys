using System;
using System.Collections.Generic;

namespace VillaManagementSys.Db
{
    public partial class Province
    {
        public Province()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PrefixCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Langtitude { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
