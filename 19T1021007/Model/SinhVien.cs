namespace _19T1021007.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenGoi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(30)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public int? IDNhom { get; set; }

        public virtual Nhom Nhom { get; set; }
    }
}
