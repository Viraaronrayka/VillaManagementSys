using System;
using System.Collections.Generic;

namespace VillaManagementSys.Db
{
    public partial class ViwVilla
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte? ChamberNo { get; set; }
        public short? Area { get; set; }
        public string? Expr1 { get; set; }
        public string? Expr2 { get; set; }
        public string? Address { get; set; }
        public decimal? Langtitude { get; set; }
        public decimal? Latitude { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte Capacity { get; set; }
        public byte CapacityMax { get; set; }
    }
}
