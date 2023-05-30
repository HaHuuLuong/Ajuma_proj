using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;


namespace Ajuma.Class
{
    internal class Functions
    {
        public static SqlConnection Conn;  //Khai báo đối tượng kết nối
        public static string connString;   //Khai báo biến chứa chuỗi kết nối

        public static void Connect()
        {
            //Thiết lập giá trị cho chuỗi kết nối
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Ajuma_proj\Ajuma\Ajuma\Database\Ajuma_MỚI .mdf"";Integrated Security=True;Connect Timeout=30";
            //connString = "";
            Conn = new SqlConnection();                 //Cấp phát đối tượng
            Conn.ConnectionString = connString;         //Kết nối
            Conn.Open();                                //Mở kết nối
                                                        // MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();       //Đóng kết nối
                Conn.Dispose();     //Giải phóng tài nguyên
                Conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }


        //CheckKey có tác dụng kiểm tra khóa trùng,
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        //RunSql có tác dụng thực thi các câu lệnh SQL
        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = Functions.Conn;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        //Thủ tục RunSqlDel tương tự như RunSql nhưng trong trường hợp xóa dữ liệu
        //nếu dữ liệu đang được dùng bởi một đối tượng khác thì không được phép xóa.
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Functions.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }

         public static bool IsDate(string d)
         {
             string[] parts = d.Split('/');//Shorttime
             if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                 return true;
             else
                 return false;
         }

         public static string ConvertDateTime(string d)
         {
             string[] parts = d.Split('/');
             string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
             return dt;
         }
        /*public static DateTime ConvertDateTime(string d)
        {
            DateTime dt = DateTime.ParseExact(d, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            return dt;
        }    
        */
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Functions.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;    // Truong gia tri
            cbo.DisplayMember = ten;    // Truong hien thi
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Functions.Conn);//paramater
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }

         public static string ChuyenSoSangChu(string sNumber)
         {
            // Tùy biến đọc thêm phần thập phân
             string[] strTachPhanSauDauPhay;
                if (sNumber.Contains('.') || sNumber.Contains(','))
                {
                    strTachPhanSauDauPhay = sNumber.Split(',', '.');
                    return(ChuyenSoSangChu(strTachPhanSauDauPhay[0]) + " phẩy " + ChuyenSoSangChu(strTachPhanSauDauPhay[1]));
                }


             int mLen, mDigit;
             string mTemp = "";
             string[] mNumText;
             //Xóa các dấu "," nếu có
             sNumber = sNumber.Replace(",", "");
             mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';'); //[không;một]
             mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
             for (int i = 0; i <= mLen; i++)
             {
                 mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                 mTemp = mTemp + " " + mNumText[mDigit];
                 if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                     break;
                 switch ((mLen - i) % 9)
                 {
                     case 0:
                         mTemp = mTemp + " tỷ";
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         break;
                     case 6:
                         mTemp = mTemp + " triệu";
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         break;
                     case 3:
                         mTemp = mTemp + " nghìn";
                         if (sNumber.Substring(i + 1, 3) == "000")
                             i = i + 3;
                         break;
                     default:
                         switch ((mLen - i) % 3)
                         {
                             case 2:
                                 mTemp = mTemp + " trăm";
                                 break;
                             case 1:
                                 mTemp = mTemp + " mươi";
                                 break;
                         }
                         break;
                 }
             }
             //Loại bỏ trường hợp x00
             mTemp = mTemp.Replace("không mươi không ", "");
             mTemp = mTemp.Replace("không mươi không", "");
             //Loại bỏ trường hợp 00x
             mTemp = mTemp.Replace("không mươi ", "linh ");
             //Loại bỏ trường hợp x0, x>=2
             mTemp = mTemp.Replace("mươi không", "mươi");
             //Fix trường hợp 10
             mTemp = mTemp.Replace("một mươi", "mười");
             //Fix trường hợp x4, x>=2
             mTemp = mTemp.Replace("mươi bốn", "mươi tư");
             //Fix trường hợp x04
             mTemp = mTemp.Replace("linh bốn", "linh tư");
             //Fix trường hợp x5, x>=2
             mTemp = mTemp.Replace("mươi năm", "mươi lăm");
             //Fix trường hợp x1, x>=2
             mTemp = mTemp.Replace("mươi một", "mươi mốt");
             //Fix trường hợp x15
             mTemp = mTemp.Replace("mười năm", "mười lăm");
             //Bỏ ký tự space
             mTemp = mTemp.Trim();
             //Viết hoa ký tự đầu tiên
             //mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
             return mTemp;
         }
        
        
        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }
        //ConvertTimeTo24 là một hàm toàn cục được viết trong Class Functions, có tác dụng chuyển đổi giờ từ dạng PM sang dạng 24h.
        public static string ConvertTimeTo24(string hour)
        {
            string h = "";
            switch (hour)
            {
                case "1":
                    h = "13";
                    break;
                case "2":
                    h = "14";
                    break;
                case "3":
                    h = "15";
                    break;
                case "4":
                    h = "16";
                    break;
                case "5":
                    h = "17";
                    break;
                case "6":
                    h = "18";
                    break;
                case "7":
                    h = "19";
                    break;
                case "8":
                    h = "20";
                    break;
                case "9":
                    h = "21";
                    break;
                case "10":
                    h = "22";
                    break;
                case "11":
                    h = "23";
                    break;
                case "12":
                    h = "0";
                    break;
            }
            return h;
        }
    }
}
