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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        List<TTNhanVien> ttnv;

        private void Form1_Load(object sender, EventArgs e)
        {
            ttnv = new List<TTNhanVien>();
            ttnv.Add(new TTNhanVien() { msnv = "NV001", tennv = "Nguyễn Thị Thu Huyền", luongcb = 8500000 });
            dtgNhanVien.DataSource = ttnv;
        }

        private void HienThiDanhSach()
        {
            dtgNhanVien.DataSource = null;
            dtgNhanVien.DataSource = ttnv;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            TTNhanVien nvMoi = new TTNhanVien();

            // Truyền đối tượng nvMoi vào form NhanVien
            NhanVien nvForm = new NhanVien(nvMoi);

            // Nếu người dùng nhấn Đồng ý, thêm vào danh sách
            if (nvForm.ShowDialog() == DialogResult.OK)
            {
                ttnv.Add(nvMoi); // Thêm nvMoi vào danh sách
                HienThiDanhSach(); // Cập nhật lại DataGridView
            }


        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dtgNhanVien.CurrentRow != null)
            {
                // Lấy đối tượng cần sửa từ DataGridView
                var nvSua = (TTNhanVien)dtgNhanVien.CurrentRow.DataBoundItem;

                // Truyền nvSua vào form NhanVien
                NhanVien nvForm = new NhanVien(nvSua);

                // Nếu người dùng nhấn Đồng ý, cập nhật lại danh sách
                if (nvForm.ShowDialog() == DialogResult.OK)
                {
                    HienThiDanhSach(); // Cập nhật lại DataGridView
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Ban co muon xoa muc da chon khong ", "Thong bao",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (dtgNhanVien.CurrentRow != null)
                {

                    var nv_xoa = (TTNhanVien)dtgNhanVien.CurrentRow.DataBoundItem;
                    ttnv.Remove(nv_xoa);


                    HienThiDanhSach();
                }
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

  