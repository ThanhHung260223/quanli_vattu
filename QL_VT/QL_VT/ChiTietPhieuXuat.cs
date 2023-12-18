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
    public partial class ChiTietPhieuXuat : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        DataSet ds = new DataSet();
        public ChiTietPhieuXuat()
        {
            InitializeComponent();
        }

        void LoadHangHoa()
        {
            string strsel = "select * from HangHoa";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "HH");
            cbHangHoa.DataSource = ds.Tables["HH"];
            cbHangHoa.DisplayMember = "TenHH";
            cbHangHoa.ValueMember = "MaHH";
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from ChiTietPhieuXuat";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "Data");
            dataGridView1.DataSource = ds.Tables["Data"];
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void ChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            txtDiaChi.Clear();
            txtDonGia.Clear();
            txtDonVi.Clear();
            txtKhachHang.Clear();
            txtNhanVien.Clear();
            txtSdt.Clear();
            txtSoLuong.Clear();
            txtSoLuongKho.Clear();
            txtSoPX.Clear();
            txtThanhTien.Clear();
            maskedTextBox1.Clear();
            txtDiaChi.Enabled = txtDonVi.Enabled = txtKhachHang.Enabled = txtNhanVien.Enabled = txtSdt.Enabled = txtSoLuongKho.Enabled = txtSoPX.Enabled = txtThanhTien.Enabled = maskedTextBox1.Enabled = false;
            txtDonGia.Enabled = txtSoLuong.Enabled = cbHangHoa.Enabled = true;
            btnThem.Enabled = btnThoat.Enabled = true;
            btnXoa.Enabled = btnLuu.Enabled = btnSua.Enabled = false;
            LoadDuLieuDataG();
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
                SqlDataAdapter da_PN = new SqlDataAdapter("select * from ChiTietPhieuXuat", conn);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from PhieuXuat where MaHDXuat='" + dtRow[2].ToString() + "'", conn);
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
                da_HD = new SqlDataAdapter("select * from Kho where MaKho='" + dtRow[1].ToString() + "'", conn);
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
            btnLuu.Enabled = true;
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_CTHD = new SqlDataAdapter("select * from ChiTietPhieuXuat", conn);
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
                string MaKho = row[1].ToString(), MaHDXuat = row[2].ToString();
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from PhieuXuat where MaHDXuat='" + MaHDXuat + "'", conn);
                DataTable ab = new DataTable();
                da_HD.Fill(ab);
                DataRow dr = ab.Rows[0];
                maskedTextBox1.Text = dr[3].ToString();
                da_HD = new SqlDataAdapter("select * from KhachHang where MaKH='" + dr[1].ToString() + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                DataRow dr1 = ab.Rows[0];
                txtKhachHang.Text = dr1[1].ToString();
                txtDiaChi.Text = dr1[2].ToString();
                txtSdt.Text = dr1[3].ToString();
                da_HD = new SqlDataAdapter("select * from NhanVien where MaNV='" + dr[2].ToString() + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr1 = ab.Rows[0];
                txtNhanVien.Text = dr1[1].ToString();
                da_HD = new SqlDataAdapter("select * from Kho where MaKho='" + MaKho + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr = ab.Rows[0];
                txtSoLuongKho.Text = dr[2].ToString();
                da_HD = new SqlDataAdapter("select * from HangHoa where MaHH='" + dr[1].ToString() + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr1 = ab.Rows[0];
                cbHangHoa.Text = dr1[1].ToString();
                txtDonVi.Text = dr1[3].ToString();
                txtDonGia.Text = row[4].ToString();
                txtSoLuong.Text = row[3].ToString();
                txtSoPX.Text = row[0].ToString();
                if (!string.IsNullOrEmpty(txtDonGia.Text) && !string.IsNullOrEmpty(txtSoLuong.Text))
                {
                    double thanhTien = Convert.ToDouble(txtDonGia.Text) * Convert.ToInt32(txtSoLuong.Text);
                    txtThanhTien.Text = thanhTien.ToString();
                }
                else
                    txtThanhTien.Text = "0";
            }
        }
    }
}
