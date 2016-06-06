using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class Class1DL
    {
        List<string> lst = new List<string>();
        
       SqlConnection con;
        string comd = string.Empty;
        DataSet ds = new DataSet();
        string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\lenovo1\documents\visual studio 2015\Projects\WcfService\DataLayer\Database1.mdf;Integrated Security=True";
        public DataSet GetBookListDL()
        {
           
            con = new SqlConnection(strConn);
             comd = "select * from tblBookInfo";

            con.Open();
            SqlCommand cmd = new SqlCommand(comd, con);
            SqlDataAdapter sda = new SqlDataAdapter(comd, con);
            sda.Fill(ds);


            return ds;
        }

        string image = "~/Upload/" + "me";

        string name = string.Empty; string author = string.Empty; int price = 0;
        DataTable dt = new DataTable();

        public void Test1(string name, string auth, int price, byte[] img)
        {
            con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("insert into tblBookInfo values(@name,@author,@price,@Image)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@author", auth);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@Image", img);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void SaveBookInfo(DataSet dss)
        { 
            dt = dss.Tables[0];

          
            name = dt.Rows[0]["Name"].ToString();
            author = dt.Rows[0]["Author"].ToString();
            price = Convert.ToInt32(dt.Rows[0]["Price"]);

            comd = "insert into tblBookInfo values()";


            con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("insert into tblBookInfo values(@name,@author,@price,@Image)", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value= image;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            // string imagepath=
        }

    }
}
