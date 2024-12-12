using QuanLySieuThi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopThuCungDNK.GUI
{
    public partial class frmQuanLy : Form
    {
        Main M = new Main();

        public static string tenDNMain = "";
        public static string maNVMain = "";

        public frmQuanLy()
        {
            InitializeComponent();
        }
        void ThongTinDangNhap()
        {
            lb_Name.Text = tenDNMain;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            ThongTinDangNhap();
        }
    }
}
