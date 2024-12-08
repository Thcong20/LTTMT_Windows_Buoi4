using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTuan4
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private TTNhanVien nv;

        public NhanVien(TTNhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
            txt_msnv.Text = nv.msnv;
            txt_tennv.Text = nv.tennv;
            txt_luongcb.Text = nv.luongcb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_msnv.Text) ||
        string.IsNullOrWhiteSpace(txt_tennv.Text) ||
        string.IsNullOrWhiteSpace(txt_luongcb.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán dữ liệu vào đối tượng TTNhanVien
            nv.msnv = txt_msnv.Text.Trim();
            nv.tennv = txt_tennv.Text.Trim();

            if (long.TryParse(txt_luongcb.Text, out long luongCB))
            {
                nv.luongcb = luongCB;
            }
            else
            {
                MessageBox.Show("Lương cơ bản không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng form với kết quả DialogResult.OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
    this.Close();
        }

        private void txt_luongcb_TextChanged(object sender, EventArgs e)
        {
            if (txt_luongcb.Text == "0")
            {
                txt_luongcb.Text = "";
            }
        }
    }
}
