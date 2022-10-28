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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _19T1021007
{
    public partial class Form1 : Form
    {
        int manhom = 0;
        int masv = 0;
        public Form1()
        {
            InitializeComponent();
            NapDSNhom();
        }

        void NapDSNhom()
        {
            var list = NhomViewModel.Getlist();
            //bdsSinhVien.DataSource = list;
            gridNhom.DataSource = list;
        }

        void NapDSSinhVien(int id)
        {

            var list = SinhVienViewModel.Getlist(id);
            //bdsSinhVien.DataSource = list;
            gridSinhVien.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = gridNhom.Rows[e.RowIndex];
            string tennhom = Convert.ToString(row.Cells["TenNhom"].Value);
            var list = NhomViewModel.Getlist();
            int id = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TenNhom.Equals(tennhom))
                {
                    id = list[i].ID;
                    manhom = id;
                }
            }
            NapDSSinhVien(manhom);
        }

        private void gridSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = gridSinhVien.Rows[e.RowIndex];
            txtTenGoi.Text = Convert.ToString(row.Cells["TenGoi"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            string email = Convert.ToString(row.Cells["Email"].Value);

            var list = SinhVienViewModel.GetlistAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Email.Equals(email))
                {
                    txtDiaChi.Text = list[i].DiaChi;
                    masv = list[i].ID;
                }
            }
        }
        private void ShowForm2()
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm2)); //Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
            this.Close(); //đóng Form hiện tại. (Form1)
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (manhom != 0)
            {
                var rs = MessageBox.Show("Ban co chac chan muon xoa nhom nay?", "Chu y", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NhomViewModel.DeleteNhom(manhom);
                    NapDSNhom();
                }
            }
        }

        private void btnXoaLienLac_Click(object sender, EventArgs e)
        {
            if (masv != 0)
            {
                var rs = MessageBox.Show("Ban co chac chan muon xoa lien lac nay?", "Chu y", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    SinhVienViewModel.DeleteSinhVien(masv);
                    NapDSNhom();
                    NapDSSinhVien(manhom);
                }
            }
        }
        private void ShowForm3()
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void bthThemLienLac_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm3)); //Tạo luồng mới
            thread.Start(); //Khởi chạy luồng
            this.Close(); //đóng Form hiện tại. (Form1)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var timkiem = txtTimKiem.Text;
                //MessageBox.Show(timkiem);
                var list = SinhVienViewModel.TimKienLienLac(timkiem);
                gridSinhVien.DataSource = list;
            }

        }
    }
}
