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
    public partial class KhachHang : Form
    {
        SqlConnection _Connsql = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        SqlDataAdapter da;
        DataSet ds_KhachHang = new DataSet();
        public KhachHang()
        {
            InitializeComponent();
        }
        void Databingding(DataTable pDT)
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", pDT, "MaKH");
            txtTenKH.DataBindings.Add("Text", pDT, "TenKH");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            txtSdt.DataBindings.Add("Text", pDT, "SDT");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from KhachHang";
            SqlDataAdapter da_KH = new SqlDataAdapter(strsel, _Connsql);
            da_KH.Fill(ds_KhachHang, "KH");
            dataGridView1.DataSource = ds_KhachHang.Tables["KH"];
        }
        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_KH = new SqlDataAdapter("select * from KhachHang", _Connsql);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_KH);
            da_KH.Update(ds_KhachHang, "KH");
            Databingding(ds_KhachHang.Tables["KH"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.ReadOnly = false;
                SqlDataAdapter da_KH = new SqlDataAdapter("select * from KhachHang", _Connsql);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_SL = new SqlDataAdapter("select * from KhachHang where MaKH='" + dtRow[0].ToString() + "'", _Connsql);
                DataTable ab = new DataTable();
                da_SL.Fill(ab);
                if (ab.Rows.Count > 1)
                {
                    MessageBox.Show("Thất bại");
                    return;
                }
                if (dtRow != null)
                {
                    dtRow.Delete();
                }
                SqlCommandBuilder cB = new SqlCommandBuilder(da_KH);
                da_KH.Update(ds_KhachHang, "KH");
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                MessageBox.Show("Thành công");
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KhachHang_Load(object sender, EventArgs e)
        {

            LoadDuLieuDataG();
            txtTenKH.Enabled = false;
            txtMaKH.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSdt.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            Databingding(ds_KhachHang.Tables["KH"]);
            dataGridView1.AllowUserToAddRows = true;
        }
    }
}
