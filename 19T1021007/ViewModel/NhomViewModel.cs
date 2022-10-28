using _19T1021007.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021007.ViewModel
{
    public class NhomViewModel
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }

        public NhomViewModel()
        {

        }

        public static void AddNhom(Nhom nhom)
        {
            var db = new AppDBContext();
            var rs = db.Nhoms.Add(nhom);
            db.SaveChanges();
        }

        public static List<NhomViewModel> Getlist()
        {
            var db = new AppDBContext();
            var rs = db.Nhoms.Select(e => new NhomViewModel
            {
                ID = e.ID,
                TenNhom = e.TenNhom,
            }).ToList();
            return rs;
        }

        public static void DeleteNhom(int id)
        {
            var db = new AppDBContext();
            var sinhvien = db.Nhoms.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nhoms.Remove(sinhvien);
            db.SaveChanges();
        }
    }
}
