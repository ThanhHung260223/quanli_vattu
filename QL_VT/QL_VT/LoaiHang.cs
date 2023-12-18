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
    public partial class LoaiHang : Form
    {
        SqlConnection _Connsql = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        SqlDataAdapter da;
        DataSet ds_LoaiHang = new DataSet();
        public LoaiHang()
        {
            InitializeComponent();
        }
        void Databingding(DataTable pDT)
        {
            txtMaLoaiHang.DataBindings.Clear();
            txtTenLoaiHang.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();
            txtMaLoaiHang.DataBindings.Add("Text", pDT, "MaLoai");
            txtTenLoaiHang.DataBindings.Add("Text", pDT, "TenLoai");
            txtTrangThai.DataBindings.Add("Text", pDT, "Flag");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from LoaiHang";
            SqlDataAdapter da_LH = new SqlDataAdapter(strsel, _Connsql);
            da_LH.Fill(ds_LoaiHang, "LH");
            dataGridView1.DataSource = ds_LoaiHang.Tables["LH"];
        }
        
        private void LoaiHang_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
            txtMaLoaiHang.Enabled = false;
            txtTenLoaiHang.Enabled = false;
            txtTrangThai.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            Databingding(ds_LoaiHang.Tables["LH"]);
            dataGridView1.AllowUserToAddRows = true;
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
                SqlDataAdapter da_KH = new SqlDataAdapter("select * from LoaiHang", _Connsql);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_SL = new SqlDataAdapter("select * from LoaiHang where MaLoai='" + dtRow[0].ToString() + "'", _Connsql);
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
                da_KH.Update(ds_LoaiHang, "LH");
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da_KH = new SqlDataAdapter("select * from LoaiHang", _Connsql);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_KH);
            da_KH.Update(ds_LoaiHang, "LH");
            Databingding(ds_LoaiHang.Tables["LH"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
