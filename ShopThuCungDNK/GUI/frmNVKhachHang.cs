using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ShopThuCungDNK.GUI
{
    public partial class frmNVKhachHang : Form
    {
        KhachHang kh = new KhachHang();
        FileXml Fxml = new FileXml();
        string MaKhachHang, TenKhachHang, Sdt, DiaChi;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void hienthiKhachHang()
        {
            DataTable dt = new DataTable();
            dt = Fxml.HienThi("KhachHang.xml");
            dvgKhachHang.DataSource = dt;

            // Thiết lập chế độ AutoSize cho các cột fill chiều rộng của DataGridView
            dvgKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dvgKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = dvgKhachHang.CurrentRow.Index;
            txtMaKH.Text = dvgKhachHang.Rows[d].Cells[0].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = dvgKhachHang.Rows[d].Cells[1].Value?.ToString() ?? string.Empty;
            txtSdt.Text = dvgKhachHang.Rows[d].Cells[2].Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = dvgKhachHang.Rows[d].Cells[3].Value?.ToString() ?? string.Empty;


        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            if (kh.KiemTra(MaKhachHang) == true)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
            }
            else
            {
                kh.ThemKhachHang(MaKhachHang, TenKhachHang, Sdt, DiaChi);
                MessageBox.Show("Ok");
                hienthiKhachHang();
                txtMaKH.Focus();
            }
        
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
           
            kh.SuaKhachHang(MaKhachHang, TenKhachHang, Sdt, DiaChi);
            MessageBox.Show("Ok");
            hienthiKhachHang();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            kh.XoaKhachHang(MaKhachHang);
            MessageBox.Show("Ok");
            hienthiKhachHang();
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("KhachHang.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "maKH";
            reader.Close();
            int index = dv.Find(txtTimKiem.Text);
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                txtTimKiem.Text = "";
                txtTimKiem.Focus();

            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã khách hàng");
                dt.Columns.Add("Họ và tên");
                dt.Columns.Add("SDT");
                dt.Columns.Add("Địa chỉ");

                object[] list = { dv[index]["maKH"], dv[index]["tenKH"], dv[index]["sdt"], dv[index]["diachi"]};
                dt.Rows.Add(list);
                dvgKhachHang.DataSource = dt;
                txtTimKiem.Text = "";
            }
        }

        private void tbnHienThi_Click(object sender, EventArgs e)
        {
            hienthiKhachHang();
        }

        public void LoadDuLieu()
        {
            MaKhachHang = txtMaKH.Text;
            TenKhachHang = txtHoTen.Text;
            Sdt = txtSdt.Text;
            DiaChi = txtDiaChi.Text;
        }
        public frmNVKhachHang()
        {
            InitializeComponent();
        }
        private void frmNVKhachHang_Load(object sender, EventArgs e)
        {
            hienthiKhachHang();
            dvgKhachHang.CellContentClick += new DataGridViewCellEventHandler(dvgKhachHang_CellContentClick);

        }
    }
}
