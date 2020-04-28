using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDienThoai.Forms
{
    public partial class frmTop5NV : Form
    {
        public frmTop5NV()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SELECT TOP 5 'Tên NV', 'Tông tiền' FROM 'Hóa đơn bán'INTER JOIN 'Nhân viên' ON 'Hóa đơn bán'.'Mã NV' = 'Nhân viên'.'Mã NV' 
            //WHERE MONTH('Ngày bán') =  tháng_nhập_vào GROUP BY 'Mã NV' ORDER BY 'Tổng tiền' ASC
            string sql= "Select Top(5) TenNV, Tongtien From tblHoaDonBan inner join tblNhanVien on tblHoaDonBan.MaNV=tblNhanVien.MaNV ";
            DataTable tblTop5;
            if (comboBox1.Text !="" && textBox1.Text!="")
            {
                sql = sql + "WHERE MONTH(Ngayban) =" + Convert.ToInt64(comboBox1.Text) + " AND YEAR(Ngayban) =" + Convert.ToInt64(textBox1.Text) + " GROUP BY MaNV ORDER BY Tongtien ASC";
            }
            else if (comboBox1.Text == "" && textBox1.Text != "")
            {
                sql = sql + "WHERE YEAR(Ngayban) =" + Convert.ToInt64(textBox1.Text) + " GROUP BY MaNV ORDER BY Tongtien ASC";
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đủ thông tin !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT MaHDN, MaSP, SoLuong, DonGia, ThanhTien, KhuyenMai FROM tblChitietHDN";
            ThucThiSQL.KetNoiCSDL();
            tblTop5 = ThucThiSQL.DocBang(sql);
            dataGridView.DataSource = tblTop5;
            dataGridView.Columns[0].HeaderText = "STT";
            dataGridView.Columns[1].HeaderText = "Tên Nhân Viên ";
            dataGridView.Columns[2].HeaderText = "Tổng tiền";
            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
