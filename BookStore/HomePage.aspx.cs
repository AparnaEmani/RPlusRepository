using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStore.ServiceReference1;
using System.Data;
using System.IO;
using System.Drawing;

namespace BookStore
{
    public partial class HomePage : System.Web.UI.Page
    {
        List<ModelClass> lst = new List<ModelClass>();  
        string[] arr = new string[50];   
        protected void Page_Load(object sender, EventArgs e)
        {


          
            AddControls();
         TestServiceClient ts = new TestServiceClient();
            DataSet ds = new DataSet();
           ds = ts.GetBookInfo();
            DataTable d = ds.Tables[0];
            int rowCount = d.Rows.Count;
            //  TextBox1.Text = arr[0].ToString();
            byte[] ba = (byte[])d.Rows[3]["Image"];
          //  MemoryStream mStream = new MemoryStream(ba);
            System.Drawing.Image img1 = byteArrayToImage(ba);




            string base64String = Convert.ToBase64String(ba, 0, ba.Length);
            Image1.ImageUrl = "data:image/png;base64," + base64String;

        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
               
                return System.Drawing.Image.FromStream(mStream);
            }
        }


       

        public void AddControls()
        {
            ImageMap im = new ImageMap();
            //lst.Add(@"~\BookStore\Images\4.jpg");
            //lst.Add(@"~\BookStore\Images\5.jpg");
            //lst.Add(@"~\BookStore\Images\6.jpg");
            //lst.Add(@"~\BookStore\Images\7.jpg");
            //lst.Add(@"~\BookStore\Images\8.jpg");


            //foreach (String pictureLink in lst)
            //{
            //    ImageMap image = new ImageMap();
            //    image.ImageUrl = pictureLink;

            //    //image.HotSpots
            //    // imagesDiv.Controls.Add(image);

            //    Panel1.Controls.Add(image);
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookDetail.aspx");
        }
    }
}