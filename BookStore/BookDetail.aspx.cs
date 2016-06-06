using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.ServiceReference1;
using System.Data;
using System.IO;
namespace BookStore
{
    public partial class BookDetail : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        TestServiceClient ts = new TestServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            //SaveBookInfo();
        }


        public void SaveBookInfo()
        {
            if (FileUpload1.HasFile)
            {

                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + str));
                string Image = "~/Upload/" + str.ToString();
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ModelClass md = new ModelClass();

            md.Name = TextBox1.Text;
            md.Author = TextBox2.Text;
            md.Price =Convert.ToInt16(TextBox3.Text);
            md.Image = FileUpload1.FileBytes;

            ts.Test1(TextBox1.Text, TextBox2.Text, Convert.ToInt16(TextBox3.Text), FileUpload1.FileBytes);

            
           
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Author");
            //dt.Columns.Add("Price");
            //dt.Columns.Add("Image");

            //DataRow dr= dt.NewRow();
            //dr["Name"] = md.Name;
            //dr["Author"] = md.Author;
            //dr["Price"] = md.Price;
            //dr["Image"] = md.Image;
            //dt.Rows.Add(dr);

           
            //ds.Tables.Add(dt);

            //ts.SaveBookInfo(ds);  
         



        }
    }
}