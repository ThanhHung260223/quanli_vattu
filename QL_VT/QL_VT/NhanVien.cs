using QL_VT.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_VT
{
    public partial class NhanVien : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        DataSet ds = new DataSet();
        public NhanVien()
        {
            InitializeComponent();
        }
        
        void LoadDuGioiTinh()
        {
            string strsel = "select GioiTinh from NhanVien";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "GioiTinh");
            cbGioiTinh.DataSource = ds.Tables["GioiTinh"];
            cbGioiTinh.DisplayMember = "GioiTinh";
            cbGioiTinh.ValueMember = "GioiTinh";
        }
        void Databingding(DataTable pDT)
        {
            txtDiaChi.DataBindings.Clear();
            txtMaNV.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            cbGioiTinh.DataBindings.Clear();
            maskedTextBoxNgaySinh.DataBindings.Clear();
            txtTenNV.DataBindings.Add("Text", pDT, "TenNV");
            txtMaNV.DataBindings.Add("Text", pDT, "MaNV");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            txtSdt.DataBindings.Add("Text", pDT, "SDT");
            cbGioiTinh.DataBindings.Add("Text", pDT, "GioiTinh");
            maskedTextBoxNgaySinh.DataBindings.Add("Text", pDT, "NgaySinh");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from NhanVien";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "NhanVien");
            dataGridView1.DataSource = ds.Tables["NhanVien"];
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

       
        private void btnThem_Click_1(object sender, EventArgs e)
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.ReadOnly = false;
                SqlDataAdapter da_NV = new SqlDataAdapter("select * from NhanVien", conn);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from PhieuNhap where MaNV='" + dtRow[0].ToString() + "'", conn);
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
                da_HD = new SqlDataAdapter("select * from PhieuXuat where MaNV='" + dtRow[0].ToString() + "'", conn);
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
                SqlCommandBuilder cB = new SqlCommandBuilder(da_NV);
                da_NV.Update(ds, "NhanVien");
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                MessageBox.Show("Thành công");
                btnSua.Enabled = btnXoa.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da_CTHD = new SqlDataAdapter("select * from NhanVien", conn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_CTHD);
            da_CTHD.Update(ds, "NhanVien");
            Databingding(ds.Tables["NhanVien"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            btnXoa.Enabled = btnSua.Enabled = false;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhanVien_Load_1(object sender, EventArgs e)
        {
            Functions.Connect();
            txtDiaChi.Clear();
            txtMaNV.Clear();
            txtSdt.Clear();
            txtTenNV.Clear();
            maskedTextBoxNgaySinh.Clear();
            LoadDuGioiTinh();
            LoadDuLieuDataG();
            Databingding(ds.Tables["NhanVien"]);
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }
    }
}
