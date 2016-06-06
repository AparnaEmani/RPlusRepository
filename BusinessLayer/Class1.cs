using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    public class Class1BL
    {
        List<string> lst = new List<string>();
        DataSet ds = new DataSet();
        Class1DL obj = new Class1DL();
        public DataSet GetBookListBL()
        {
            
            ds = obj.GetBookListDL();

            return ds;
        }
        public void Test1(string name, string auth, int price, byte[] img)
        {
            obj.Test1(name, auth, price, img);
        }


        public void SaveBookInfo(DataSet dss)
        {
            obj.SaveBookInfo(dss);
        }
    }
}
