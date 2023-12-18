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
    public partial class HangHoa : Form
    {
        SqlConnection _Connsql = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");
        SqlDataAdapter da;
        DataSet ds_HangHoa = new DataSet();
        public HangHoa()
        {
            InitializeComponent();
        }
        void LoadDuLieuMaLoai()
        {
            string strsel = "select * from LoaiHang";
            SqlDataAdapter da_HD = new SqlDataAdapter(strsel, _Connsql);
            da_HD.Fill(ds_HangHoa, "LoaiHang");
            cbMaLoai.DataSource = ds_HangHoa.Tables["LoaiHang"];
            cbMaLoai.DisplayMember = "TenLoai";
            cbMaLoai.ValueMember = "MaLoai";
        }
        void Databingding(DataTable pDT)
        {
            txtMaHangHoa.DataBindings.Clear();
            txtTenHangHoa.DataBindings.Clear();
            txtDonVi.DataBindings.Clear();
            cbMaLoai.DataBindings.Clear();
            txtMaHangHoa.DataBindings.Add("Text", pDT, "MaHH");
            txtTenHangHoa.DataBindings.Add("Text", pDT, "TenHH");
            txtDonVi.DataBindings.Add("Text", pDT, "DonVi");
            cbMaLoai.DataBindings.Add("Text", pDT, "MaLoai");
        }
        void LoadDuLieuDataG()
        {
            string strsel = "select * from HangHoa";
            SqlDataAdapter da_KH = new SqlDataAdapter(strsel, _Connsql);
            da_KH.Fill(ds_HangHoa, "HH");
            dataGridView1.DataSource = ds_HangHoa.Tables["HH"];
        }

        
        private void HangHoa_Load(object sender, EventArgs e)
        {
            LoadDuLieuMaLoai();
            LoadDuLieuDataG();
            txtMaHangHoa.Clear();
            txtTenHangHoa.Clear();
            txtDonVi.Clear();
            cbMaLoai.Enabled = false;
            txtMaHangHoa.Enabled = false;
            txtTenHangHoa.Enabled = false;
            txtDonVi.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            Databingding(ds_HangHoa.Tables["HH"]);
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
                SqlDataAdapter da_KH = new SqlDataAdapter("select * from HangHoa", _Connsql);
                DataRowView drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                DataRow dtRow = drv.Row;
                SqlDataAdapter da_SL = new SqlDataAdapter("select * from HangHoa where MaHH='" + dtRow[0].ToString() + "'", _Connsql);
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
                da_KH.Update(ds_HangHoa, "HH");
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
            SqlDataAdapter da_HH = new SqlDataAdapter("select * from HangHoa", _Connsql);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_HH);
            da_HH.Update(ds_HangHoa, "HH");
            Databingding(ds_HangHoa.Tables["HH"]);
            MessageBox.Show("Thành công");
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
