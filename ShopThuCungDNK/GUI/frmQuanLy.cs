using QuanLySieuThi.Class;
using ShopThuCungDNK.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQuanLy : Form
    {
        Main M = new Main();
        FileXml Fxml = new FileXml();
        ThongKe thongKe = new ThongKe();   
        public static string tenDNMain = "";
        public static string maNVMain = "";
        List<KeyValuePair<string, int>> ketQua = new List<KeyValuePair<string, int>>();
        decimal tongTien = 0;
        public frmQuanLy()
        {
            InitializeComponent();
        }
        void ThongTinDangNhap()
        {
            lb_Name.Text = tenDNMain;
        }
        

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            ThongTinDangNhap();
            getData();
        }

   

        public void getData()
        {
            // Bước 1: Lấy dữ liệu từ file Hóa Đơn
            DataTable hoaDonData = Fxml.HienThi("hoaDon.xml");

            // Bước 2: Lấy dữ liệu từ file Chi Tiết Hóa Đơn
            DataTable chiTietHoaDonData = Fxml.HienThi("chiTietHoaDon.xml");

            // Bước 3: Lấy dữ liệu từ file Thú Cưng
            DataTable thuCungData = Fxml.HienThi("thuCung.xml");
            DataTable LoaiThuCungData = Fxml.HienThi("LoaiThuCung.xml");
            ketQua = thongKe.TinhSoLuongHoaDon(chiTietHoaDonData, thuCungData, LoaiThuCungData);
            tongTien = thongKe.TinhTongHoaDon(chiTietHoaDonData);
            int index = 0;
            foreach (var hoaDon in ketQua)
            {
                // Lấy tên thú cưng và số lượng hóa đơn
                string tenThuCung = hoaDon.Key;
                int soLuongHoaDon = hoaDon.Value;

                // Gán giá trị cho các label có sẵn
                switch (index)
                {
                    case 0:
                        label2.Text = $"{tenThuCung}";
                        break;
                    case 1:
                        label4.Text = $"{tenThuCung}";
                        break;
                    case 2:
                        label6.Text = $"Tên thú cưng: {tenThuCung}, Số lượng hóa đơn: {soLuongHoaDon}";
                        break;
                    // Tiếp tục nếu có thêm các label khác
                    // case 3: label4.Text = ... break;
                    // case 4: label5.Text = ... break;
                    default:
                        // Nếu số lượng kết quả vượt quá số lượng Label có sẵn
                        break;
                }

                // Tăng index lên để gán cho label tiếp theo
                index++;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frmQLNhanVien = new frmQLNhanVien();
            frmQLNhanVien.TopLevel = false;

            if (panelMain.Controls.Count > 0)
            {
                panelMain.Controls.Clear();
            }

            // Đặt kích thước của frmNVTrangChu bằng kích thước của panelDesktop
            frmQLNhanVien.Size = panelMain.ClientSize;


            panelMain.Controls.Add(frmQLNhanVien);

            // Đảm bảo frmNVTrangChu hiển thị lên trên cùng
            frmQLNhanVien.BringToFront();

            frmQLNhanVien.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
