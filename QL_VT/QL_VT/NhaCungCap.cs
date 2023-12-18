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
    public partial class NhaCungCap : Form
    {
        
        SqlConnection _Connsql = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        SqlDataAdapter da;
        DataSet ds_NhaCC = new DataSet();
        public NhaCungCap()
        {
            InitializeComponent();
        }
        void Databingding(DataTable pDT)
        {
            txtMaNhaCC.DataBindings.Clear();
            txtTenNhaCC.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
            txtMaNhaCC.DataBindings.Add("Text", pDT, "MaNCC");
            txtTenNhaCC.DataBindings.Add("Text", pDT, "TenNCC");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            txtSdt.DataBindings.Add("Text", pDT, "SDT");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from NhaCC";
            SqlDataAdapter da_KH = new SqlDataAdapter(strsel, _Connsql);
            da_KH.Fill(ds_NhaCC, "NCC");
            dataGridView1.DataSource = ds_NhaCC.Tables["NCC"];
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
                SqlDataAdapter da_NhaCC = new SqlDataAdapter("select * from NhaCC", _Connsql);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_SL = new SqlDataAdapter("select * from NhaCC where MaNCC='" + dtRow[0].ToString() + "'", _Connsql);
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
                SqlCommandBuilder cB = new SqlCommandBuilder(da_NhaCC);
                da_NhaCC.Update(ds_NhaCC, "NCC");
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
            SqlDataAdapter da_NhaCC = new SqlDataAdapter("select * from NhaCC", _Connsql);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_NhaCC);
            da_NhaCC.Update(ds_NhaCC, "NCC");
            Databingding(ds_NhaCC.Tables["NCC"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDuLieuDataG();
            txtMaNhaCC.Enabled = false;
            txtTenNhaCC.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSdt.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            Databingding(ds_NhaCC.Tables["NCC"]);
            dataGridView1.AllowUserToAddRows = true;
        }
    }
}
