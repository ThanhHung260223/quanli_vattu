using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_VT.Class;
using QL_VT;


namespace QL_VT
{
    
    public partial class frmMain : Form
    {
        const int heightOfButtons = 42;
        string TenUser = "", MatKhau = "";
        int Quyen = 0;
        public frmMain()
        {
            InitializeComponent();
            this.TenUser = TenUser;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
        }


        private void frmMain1_Load(object sender, EventArgs e)
        {
            pnlCenter.AutoScroll = true;
            btnRpTypeProduct.Text = "Hàng hóa";
        }
        private Form activeForm = null;
        private void openFormChill(Form chill)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = chill;
            chill.TopLevel = false;
            int Height = chill.Height;
            chill.MaximumSize = new Size(815, Height);
            chill.FormBorderStyle = FormBorderStyle.None;
            chill.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(chill);
            pnlForm.Tag = chill;
            chill.BringToFront();
            chill.Show();
        }
        bool expand1 = false, expand2 = false, expand3 = false;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoiceDetail_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new ChiTietPhieuXuat());
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new PhieuXuat());
            }
        }

        private void btnEntryDetail_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new ChiTietPhieuNhap());
            }
        }

        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new PhieuNhap());
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new HangHoa());
            }
        }

        private void btnTypeProduct_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new LoaiHang());
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new NhaCungCap());
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new KhachHang());
            }
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            if (Quyen == 2)
            {
                openFormChill(new NhanVien());
            }
        }

        private void btnListAccount_Click(object sender, EventArgs e)
        {
            if (Quyen != 0)
            {
                openFormChill(new TaiKhoan());
            }
        }

        private void btnRpProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRpTypeProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRpSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnRpGuest_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand1 == false)
            {
                int Report_X, Report_Y, Width, Height;
                if (expand2 == true)
                {
                    ddwCategory.Height -= (11 * heightOfButtons);
                    if (ddwCategory.Height <= ddwCategory.MinimumSize.Height)
                    {
                        timer2.Stop();
                        expand2 = false;
                    }
                    Report_Y = (int)ddwReport.Location.Y - 10 * heightOfButtons;
                    Report_X = (int)ddwReport.Location.X;
                    Width = (int)pnlCenter.Width - 13 * heightOfButtons;
                    Height = (int)pnlCenter.Height;
                    ddwReport.Location = new Point(Report_X, Report_Y);
                    pnlCenter.Size = new Size(Width, Height);
                }
                if (expand3 == true)
                {
                    ddwReport.Height -= (7 * heightOfButtons);
                    if (ddwReport.Height <= ddwReport.MinimumSize.Height)
                    {
                        timer3.Stop();
                        expand3 = false;
                    }
                    Width = (int)pnlCenter.Width - 7 * heightOfButtons;
                    Height = (int)pnlCenter.Height; ;
                    pnlCenter.Size = new Size(Width, Height);
                }
                ddwAccount.Height += heightOfButtons;
                if (ddwAccount.Height >= ddwAccount.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand1 = true;
                }
                int Category_Y = (int)ddwCategory.Location.Y + heightOfButtons, Category_X = (int)ddwCategory.Location.X;
                Report_Y = (int)ddwReport.Location.Y + heightOfButtons;
                Report_X = (int)ddwReport.Location.X;
                Width = (int)pnlCenter.Width + heightOfButtons;
                Height = (int)pnlCenter.Height;
                ddwCategory.Location = new Point(Category_X, Category_Y);
                ddwReport.Location = new Point(Report_X, Report_Y);
                pnlCenter.Size = new Size(Width, Height);
            }
            else
            {
                ddwAccount.Height -= heightOfButtons;
                if (ddwAccount.Height <= ddwAccount.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand1 = false;
                }
                int Category_Y = (int)ddwCategory.Location.Y - heightOfButtons, Category_X = (int)ddwCategory.Location.X;
                int Report_Y = (int)ddwReport.Location.Y - heightOfButtons, Report_X = (int)ddwReport.Location.X;
                int Width = (int)pnlCenter.Width - heightOfButtons, Height = (int)pnlCenter.Height;
                ddwCategory.Location = new Point(Category_X, Category_Y);
                ddwReport.Location = new Point(Report_X, Report_Y);
                pnlCenter.Size = new Size(Width, Height);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (expand2 == false)
            {
                int Report_X, Report_Y, Width, Height;
                if (expand1 == true)
                {
                    ddwAccount.Height -= heightOfButtons;
                    if (ddwAccount.Height <= ddwAccount.MinimumSize.Height)
                    {
                        timer1.Stop();
                        expand1 = false;
                    }
                    int Category_Y = (int)ddwCategory.Location.Y - heightOfButtons, Category_X = (int)ddwCategory.Location.X;
                    Report_Y = (int)ddwReport.Location.Y - heightOfButtons;
                    Report_X = (int)ddwReport.Location.X;
                    Width = (int)pnlCenter.Width - heightOfButtons;
                    Height = (int)pnlCenter.Height;
                    ddwCategory.Location = new Point(Category_X, Category_Y);
                    ddwReport.Location = new Point(Report_X, Report_Y);
                    pnlCenter.Size = new Size(Width, Height);
                }
                if (expand3 == true)
                {
                    ddwReport.Height -= (7 * heightOfButtons);
                    if (ddwReport.Height <= ddwReport.MinimumSize.Height)
                    {
                        timer3.Stop();
                        expand3 = false;
                    }
                    Width = (int)pnlCenter.Width - 7 * heightOfButtons;
                    Height = (int)pnlCenter.Height; ;
                    pnlCenter.Size = new Size(Width, Height);
                }
                ddwCategory.Height += (11 * heightOfButtons);
                if (ddwCategory.Height >= ddwCategory.MaximumSize.Height)
                {
                    timer2.Stop();
                    expand2 = true;
                }
                Report_Y = (int)ddwReport.Location.Y + 10 * heightOfButtons;
                Report_X = (int)ddwReport.Location.X;
                Width = (int)pnlCenter.Width + 13 * heightOfButtons;
                Height = (int)pnlCenter.Height;
                ddwReport.Location = new Point(Report_X, Report_Y);
                pnlCenter.Size = new Size(Width, Height);
            }
            else
            {
                ddwCategory.Height -= (11 * heightOfButtons);
                if (ddwCategory.Height <= ddwCategory.MinimumSize.Height)
                {
                    timer2.Stop();
                    expand2 = false;
                }
                int Report_Y = (int)ddwReport.Location.Y - 10 * heightOfButtons, Report_X = (int)ddwReport.Location.X;
                int Width = (int)pnlCenter.Width - 13 * heightOfButtons, Height = (int)pnlCenter.Height;
                ddwReport.Location = new Point(Report_X, Report_Y);
                pnlCenter.Size = new Size(Width, Height);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (expand3 == false)
            {
                int Report_X, Report_Y, Width, Height;
                if (expand1 == true)
                {
                    ddwAccount.Height -= heightOfButtons;
                    if (ddwAccount.Height <= ddwAccount.MinimumSize.Height)
                    {
                        timer1.Stop();
                        expand1 = false;
                    }
                    int Category_Y = (int)ddwCategory.Location.Y - heightOfButtons, Category_X = (int)ddwCategory.Location.X;
                    Report_Y = (int)ddwReport.Location.Y - heightOfButtons;
                    Report_X = (int)ddwReport.Location.X;
                    Width = (int)pnlCenter.Width - heightOfButtons;
                    Height = (int)pnlCenter.Height;
                    ddwCategory.Location = new Point(Category_X, Category_Y);
                    ddwReport.Location = new Point(Report_X, Report_Y);
                    pnlCenter.Size = new Size(Width, Height);
                }
                if (expand2 == true)
                {
                    ddwCategory.Height -= (11 * heightOfButtons);
                    if (ddwCategory.Height <= ddwCategory.MinimumSize.Height)
                    {
                        timer2.Stop();
                        expand2 = false;
                    }
                    Report_Y = (int)ddwReport.Location.Y - 10 * heightOfButtons;
                    Report_X = (int)ddwReport.Location.X;
                    Width = (int)pnlCenter.Width - 13 * heightOfButtons;
                    Height = (int)pnlCenter.Height;
                    ddwReport.Location = new Point(Report_X, Report_Y);
                    pnlCenter.Size = new Size(Width, Height);
                }
                ddwReport.Height += (7 * heightOfButtons);
                if (ddwReport.Height >= ddwReport.MaximumSize.Height)
                {
                    timer3.Stop();
                    expand3 = true;
                }
                Width = (int)pnlCenter.Width + 7 * heightOfButtons;
                Height = (int)pnlCenter.Height;
                pnlCenter.Size = new Size(Width, Height);
            }
            else
            {
                ddwReport.Height -= (7 * heightOfButtons);
                if (ddwReport.Height <= ddwReport.MinimumSize.Height)
                {
                    timer3.Stop();
                    expand3 = false;
                }
                int Width = (int)pnlCenter.Width - 7 * heightOfButtons, Height = (int)pnlCenter.Height; ;
                pnlCenter.Size = new Size(Width, Height);
            }
        }

        private void ddwAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRpDecreaseProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRpIncreaseProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnRpStorage_Click(object sender, EventArgs e)
        {

        }
    }
}
