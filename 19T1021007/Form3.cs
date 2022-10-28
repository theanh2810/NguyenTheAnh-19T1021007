using _19T1021007.Model;
using _19T1021007.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19T1021007
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            NapDSNhom();
        }
        private void ShowForm1()
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        void NapDSNhom()
        {
            var list = NhomViewModel.Getlist();
            //bdsSinhVien.DataSource = list;
            for(int i = 0; i < list.Count; i++)
            {
                cbxNhom.Items.Add(list[i].TenNhom);
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var list = NhomViewModel.Getlist();
            var id = 0;
            var chimuc = cbxNhom.SelectedIndex;
            for(int i = 0; i < list.Count; i++)
            {
                if (i == chimuc)
                {
                    id = list[i].ID;
                }
            }
            var sv = new SinhVien
            {
                TenGoi = txtTenGoi.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                SDT = txtSDT.Text,
                IDNhom = id,
                 
            };
            SinhVienViewModel.AddSinhVien(sv);
            Thread thread = new Thread(new ThreadStart(ShowForm1)); //Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
            this.Close(); //đóng Form hiện tại. (Form1)
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm1)); //Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
            this.Close(); //đóng Form hiện tại. (Form1)
        }
    }
}
