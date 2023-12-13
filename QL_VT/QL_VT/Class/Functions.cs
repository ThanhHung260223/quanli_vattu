using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_VT.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        // tạo phương thức
        public static void Connect()
        {
            con = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = VLXD; Integrated Security = True");

            // kiểm tra kết nối
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                //MessageBox.Show("Kết nối database thành công");
            }
            else
                MessageBox.Show("Kết nối database thất bại");

        }
        public static SqlConnection getStringConnect()
        {
            return con;
        }
        // Dừng việc kết nối đến database
        public static void Disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose(); // giải phóng tài nguyên
                con = null;
            }
        }

        //

        // phương thức thực thi câu lệnh select dữ liệu
        public static DataTable GetDataTable(string str)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(str, con);
            adt.Fill(dt);
            return dt;
        }
        // phương thức thực thi insert, update, delete

        public static void RunSQL(string str)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con; // gán kết nối
            cmd.CommandText = str;// gán lệnh sql
            try
            {
                cmd.ExecuteNonQuery();// thực hiện câu lệnh
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();// giải phóng bộ nhớ
            cmd = null;

        }
        public static bool CheckKey(string str)
        {
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable table = new DataTable();
            ad.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;// có tồn tại khóa ròi
            }
            return false;    // chưa tồn tại khóa
        }
        public static void fillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;//  trường lưu vào database
            cbo.DisplayMember = ten; // truong hien thi
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
    }
}
