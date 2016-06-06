using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer;
using System.Data;
namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : ITestService
    {
        List<MOdelClass> lst = new List<MOdelClass>();
        DataSet ds = new DataSet();
        Class1BL obj = new Class1BL();

        MOdelClass mdObj = new MOdelClass();

        public void Test(MOdelClass md)
        {

           
        }

        public void Test1(string name, string auth, int price, byte[] img)
        {
            // throw new NotImplementedException();
            obj.Test1(name,auth,price,img);
        }



        public DataSet DoWork()
        {
            
            ds = obj.GetBookListBL();

            return ds;
        }

        public DataSet GetBookInfo()
        {
            Class1BL obj = new Class1BL();
            ds = obj.GetBookListBL();
            //DataTable dt = ds.Tables[0];
            //MOdelClass md = new MOdelClass();
            //md.Name = dt.Rows[0]["Name"].ToString();
            //md.Author = dt.Rows[0]["Name"].ToString();
            //md.Price = Convert.ToInt32(dt.Rows[0]["Price"]);
            //md.Image = (byte[])dt.Rows[0]["Image"];

            //lst.Add(md);

            return ds;
        }

        public void SaveBookInfo(DataSet dss)
        {
            obj.SaveBookInfo(dss);
        }

        
    }
}
