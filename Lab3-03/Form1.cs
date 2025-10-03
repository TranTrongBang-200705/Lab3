using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_03
{
    public partial class Form1 : Form
    {
        public class SinhVien
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string Khoa { get; set; }
            public double Diem { get; set; }
        }

        private List<SinhVien> danhSach = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this); // truyền FormMain
            f.ShowDialog();
        }
        public bool ThemSinhVien(SinhVien sv)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == sv.Ma)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // Thêm vào DataGridView (vì đã có sẵn cột)
            int stt = dgvSinhVien.Rows.Count; // số thứ tự = số dòng hiện tại
            dgvSinhVien.Rows.Add(stt, sv.Ma, sv.Ten, sv.Khoa, sv.Diem);
            return true;
        }
        private void HienThi()
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = danhSach;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimKiem.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.IsNewRow) continue;

                string tenSV = row.Cells[2].Value?.ToString().ToLower() ?? "";

                // Nếu có chứa từ khóa thì hiển thị, không thì ẩn
                row.Visible = tenSV.Contains(key);
            }
        }
         private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
         {
             Form2 f = new Form2(this); // truyền FormMain
             f.ShowDialog();
         }
         private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Close();
        }
    }
}

