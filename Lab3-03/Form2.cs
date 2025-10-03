using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab3_03.Form1;

namespace Lab3_03
{
    public partial class Form2 : Form
    {
        private Form1 Form1;

        public Form2(Form1 f)
        {
            InitializeComponent();
            Form1 = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cmbKhoa.Items.Add("Công nghệ thông tin");
            cmbKhoa.Items.Add("Ngôn ngữ Anh");
            cmbKhoa.Items.Add("Quản trị kinh doanh");
            cmbKhoa.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
            string.IsNullOrWhiteSpace(txtHoTen.Text) ||
            string.IsNullOrWhiteSpace(txtDTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!double.TryParse(txtDTB.Text, out double diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng 0 - 10!");
                return;
            }

            // Tạo đối tượng sinh viên
            SinhVien sv = new SinhVien()
            {
                Ma = txtMSSV.Text,
                Ten = txtHoTen.Text,
                Khoa = cmbKhoa.SelectedItem.ToString(),
                Diem = diem
            };

            // Gọi FormMain để thêm
            if (Form1.ThemSinhVien(sv))
            {
                this.Close(); // thành công thì đóng form nhập
            }
        }
    }
}
