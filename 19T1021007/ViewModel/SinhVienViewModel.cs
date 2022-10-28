using _19T1021007.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021007.ViewModel
{
    public class SinhVienViewModel
    {
        public int ID { get; set; }

        public string TenGoi { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public int? IDNhom { get; set; }

        public SinhVienViewModel()
        {

        }

        public static void AddSinhVien(SinhVien nguoi)
        {
            var db = new AppDBContext();
            var rs = db.SinhViens.Add(nguoi);
            db.SaveChanges();
        }


        public static List<SinhVienViewModel> Getlist(int ID)
        {

            var db = new AppDBContext();
            var rs = db.SinhViens.Where(e => e.IDNhom == ID).Select(e => new SinhVienViewModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }

        public static List<SinhVienViewModel> GetlistAll()
        {

            var db = new AppDBContext();
            var rs = db.SinhViens.Select(e => new SinhVienViewModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }

        public static List<SinhVienViewModel> TimKienLienLac(string SDT)
        {

            var db = new AppDBContext();
            var rs = db.SinhViens.Where(e => e.SDT == SDT).Select(e => new SinhVienViewModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }

        public static void DeleteSinhVien(int id)
        {
            var db = new AppDBContext();
            var nguoi = db.SinhViens.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.SinhViens.Remove(nguoi);
            db.SaveChanges();
        }
    }
}
