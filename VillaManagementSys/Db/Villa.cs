using System;
using System.Collections.Generic;

namespace VillaManagementSys.Db
{
    public partial class Villa
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte ChamberNo { get; set; }
        public short? Area { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; } = null!;
        public string? Langtitude { get; set; }
        public string? Latitude { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? SpecialTag { get; set; }
        public byte Capacity { get; set; }
        public byte CapacityMax { get; set; }

        public virtual City City { get; set; } = null!;
    }
}
