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
using System.Data.SqlClient;

namespace QL_VT
{
    public partial class TaiKhoan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        DataSet ds = new DataSet();
        public TaiKhoan()
        {
            InitializeComponent();

        }
        void loadCBLoai()
        {
            string strsel = "select Loai from NguoiDung";
            SqlDataAdapter da_Khoa = new SqlDataAdapter(strsel, conn);
            da_Khoa.Fill(ds, "Loai");
            cbLoaiND.DataSource = ds.Tables["Loai"];
            cbLoaiND.DisplayMember = "Loai";
            cbLoaiND.ValueMember = "Loai";
        }
        void Databingding(DataTable pDT)
        {
            txtMatKhau.DataBindings.Clear();
            txtNhapLaiMk.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            cbLoaiND.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", pDT, "MatKhau");
            txtNhapLaiMk.DataBindings.Add("Text", pDT, "MatKhau");
            txtTenDangNhap.DataBindings.Add("Text", pDT, "TenND");
            cbLoaiND.DataBindings.Add("Text", pDT, "Loai");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from NguoiDung";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "Data");
            dataGridView1.DataSource = ds.Tables["Data"];
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            //luu();
        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            
            btnThem.Enabled = true;
            Functions.Connect();
            LoadDuLieuDataG();
            loadCBLoai();
            Databingding(ds.Tables["Data"]);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.ReadOnly = false;
                SqlDataAdapter da_PN = new SqlDataAdapter("select * from NguoiDung", conn);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from NguoiDung_NhanVien where TenND='" + dtRow[0].ToString() + "'", conn);
                DataTable ab = new DataTable();
                da_HD.Fill(ab);
                if (ab.Rows.Count > 0)
                {
                    MessageBox.Show("Thất bại");
                    btnSua.Enabled = btnXoa.Enabled = false;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.ReadOnly = true;
                    return;
                }
                if (dtRow != null)
                {
                    dtRow.Delete();
                }
                SqlCommandBuilder cB = new SqlCommandBuilder(da_PN);
                da_PN.Update(ds, "Data");
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                MessageBox.Show("Thành công");
                btnSua.Enabled = btnXoa.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_CTHD = new SqlDataAdapter("select * from NguoiDung", conn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_CTHD);
            da_CTHD.Update(ds, "Data");
            Databingding(ds.Tables["Data"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            btnSua.Enabled = btnXoa.Enabled = false;
        }
    }
}
