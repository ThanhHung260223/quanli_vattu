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
    public partial class PhieuXuat : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        DataSet ds = new DataSet();
        public PhieuXuat()
        {
            InitializeComponent();
        }

        void LoadDuGioiTinh()
        {
            string strsel = "select * from KhachHang";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "Khach");
            cbTenNhaCC.DataSource = ds.Tables["Khach"];
            cbTenNhaCC.DisplayMember = "TenKH";
            cbTenNhaCC.ValueMember = "MaKH";
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from PhieuXuat";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "Data");
            dataGridView1.DataSource = ds.Tables["Data"];
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            txtMaPX.Clear();
            txtTenNV.Clear();
            maskedTextBox1.Clear();
            LoadDuLieuDataG();
            LoadDuGioiTinh();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnThem.Enabled = true;
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
            flag = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.ReadOnly = false;
                SqlDataAdapter da_PN = new SqlDataAdapter("select * from PhieuXuat", conn);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from NhanVien where MaNV='" + dtRow[3].ToString() + "'", conn);
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
                da_HD = new SqlDataAdapter("select * from KhachHang where TenKH='" + dtRow[1].ToString() + "'", conn);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_CTHD = new SqlDataAdapter("select * from PhieuXuat", conn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_CTHD);
            da_CTHD.Update(ds, "Data");
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            btnXoa.Enabled = btnSua.Enabled = false;
            flag = true;
        }
        bool flag = true;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                DataRow row = (dataGridView1.Rows[dataGridView1.CurrentRow.Index].DataBoundItem as DataRowView).Row;
                string MaKH = row[1].ToString(), MaNV = row[2].ToString();
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from KhachHang where MaKH='" + MaKH + "'", conn);
                DataTable ab = new DataTable();
                da_HD.Fill(ab);
                DataRow dr = ab.Rows[0];
                cbTenNhaCC.Text = dr[1].ToString();
                da_HD = new SqlDataAdapter("select * from NhanVien where MaNV='" + MaNV + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr = ab.Rows[0];
                txtTenNV.Text = dr[1].ToString();
                txtMaPX.Text = row[0].ToString();
                maskedTextBox1.Text = row[3].ToString();
            }
        }
    }
}
