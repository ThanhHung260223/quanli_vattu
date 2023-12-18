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
    public partial class ChiTietPhieuNhap : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        DataSet ds = new DataSet();
        public ChiTietPhieuNhap()
        {
            InitializeComponent();
        }

        void LoadHH()
        {
            string strsel = "select * from HangHoa";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "HangHoa");
            cbHangHoa.DataSource = ds.Tables["HangHoa"];
            cbHangHoa.DisplayMember = "TenHH";
            cbHangHoa.ValueMember = "MaHH";
        }

        void LoadDuLieuDataG()
        {
            string strsel = "select * from ChiTietPhieuNhap";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, conn);
            da_HD.Fill(ds, "Data");
            dataGridView1.DataSource = ds.Tables["Data"];
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void ChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnThem.Enabled = true;
            txtDonGia.Clear();
            txtDonVi.Clear();
            txtNhaCC.Clear();
            txtNhanVien.Clear();
            txtSoLuong.Clear();
            txtSoPN.Clear();
            txtThanhTien.Clear();
            maskedTextBox1.Clear();
            LoadDuLieuDataG();
            LoadHH();
            txtDonVi.Enabled = txtNhaCC.Enabled = txtNhanVien.Enabled = txtSoPN.Enabled = txtThanhTien.Enabled = maskedTextBox1.Enabled = false;
            cbHangHoa.Enabled = txtSoLuong.Enabled = txtDonGia.Enabled = true;
            btnXoa.Enabled = btnSua.Enabled = false;
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
                SqlDataAdapter da_PN = new SqlDataAdapter("select * from ChiTietPhieuNhap", conn);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from PhieuNhap where MaHDNhap='" + dtRow[2].ToString() + "'", conn);
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
                da_HD = new SqlDataAdapter("select * from HangHoa where TenHH='" + dtRow[1].ToString() + "'", conn);
                ab = new DataTable();
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
            SqlDataAdapter da_CTHD = new SqlDataAdapter("select * from ChiTietPhieuNhap", conn);
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
                string MaHH = row[1].ToString(), MaHDNhap = row[2].ToString();
                SqlDataAdapter da_HD = new SqlDataAdapter("select * from HangHoa where MaHH='" + MaHH + "'", conn);
                DataTable ab = new DataTable();
                da_HD.Fill(ab);
                DataRow dr = ab.Rows[0];
                cbHangHoa.Text = dr[1].ToString();
                txtDonVi.Text = dr[3].ToString();
                da_HD = new SqlDataAdapter("select * from PhieuNhap where MaHDNhap='" + MaHDNhap + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr = ab.Rows[0];
                da_HD = new SqlDataAdapter("select * from NhaCC where MaNCC='" + dr[1].ToString() + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                DataRow dr1 = ab.Rows[0];
                txtNhaCC.Text = dr1[1].ToString();
                da_HD = new SqlDataAdapter("select * from NhanVien where MaNV='" + dr[2].ToString() + "'", conn);
                ab = new DataTable();
                da_HD.Fill(ab);
                dr1 = ab.Rows[0];
                txtNhanVien.Text = dr1[1].ToString();
                txtDonGia.Text = row[4].ToString();
                txtSoLuong.Text = row[3].ToString();
                txtSoPN.Text = row[0].ToString();
                maskedTextBox1.Text = dr[3].ToString();
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
