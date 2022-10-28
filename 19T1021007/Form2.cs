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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void ShowForm1()
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var nhom = new Nhom
            {
                TenNhom = txtTenNhom.Text,
            };
            NhomViewModel.AddNhom(nhom);
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
