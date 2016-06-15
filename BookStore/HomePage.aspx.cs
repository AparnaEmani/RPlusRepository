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
        TestServiceClient ts = new TestServiceClient();
        DataSet ds = new DataSet();
        DataTable d = new DataTable();

        public HomePage()
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {


          
        
         TestServiceClient ts = new TestServiceClient();
            
           ds = ts.GetBookInfo();
             d = ds.Tables[0];
            int rowCount = d.Rows.Count;
            //  TextBox1.Text = arr[0].ToString();
            AddControls();
          //  byte[] ba = (byte[])d.Rows[3]["Image"];
          //  MemoryStream mStream = new MemoryStream(ba);
           // System.Drawing.Image img1 = byteArrayToImage(ba);




            //string base64String = Convert.ToBase64String(ba, 0, ba.Length);
            //Image1.ImageUrl = "data:image/png;base64," + base64String;

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
            int i = 0;
            
            TableRow tblRow = new TableRow();
            TableCell cell1;// = new TableCell(); 
            Label lblName = new Label();
            Label lblAuthor = new Label();
            Label lblPrice = new Label();
            foreach (var row in d.Rows)
            {
                // Panel pnl = new Panel();

            

               

                ImageMap image = new ImageMap();
               tblRow = new TableRow();
                tblRow.ID = i.ToString();
                //    image.ImageUrl = pictureLink;

                //    //image.HotSpots
                //    // imagesDiv.Controls.Add(image);

                byte[] ba = (byte[])d.Rows[i]["Image"]; 
                string base64String = Convert.ToBase64String(ba, 0, ba.Length);
                image.ImageUrl = "data:image/png;base64," + base64String;

                cell1 = new TableCell();
                cell1.Text = d.Rows[i]["ID"].ToString();
                cell1.Visible = false;
                cell1.Attributes.Add("onclick", "myFunction");
                tblRow.Cells.Add(cell1);

                cell1 = new TableCell();
                cell1.Controls.Add(image);
                tblRow.Cells.Add(cell1);
           
               
                cell1 = new TableCell();
                cell1.Text = d.Rows[i]["Name"].ToString();
                tblRow.Cells.Add(cell1);


                cell1 = new TableCell();
                cell1.Text = d.Rows[i]["Author"].ToString();
                tblRow.Cells.Add(cell1);


                cell1 = new TableCell();
                cell1.Text= d.Rows[i]["Price"].ToString();
                tblRow.Cells.Add(cell1);
              

                
             


                myTable.Rows.Add(tblRow);
                i++;
               
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookDetail.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string myStringVariable = "nishant";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

            int id =Convert.ToInt16(HiddenField1.Value);
            int rowID = Convert.ToInt16(d.Rows[id-1][0]);
            ts.Delete(rowID);
            Response.Redirect("HomePage.aspx");
        }


        

    }
}