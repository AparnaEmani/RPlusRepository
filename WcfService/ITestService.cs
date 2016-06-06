using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        DataSet DoWork();

        [OperationContract]
        void SaveBookInfo(DataSet dss);


        [OperationContract]
        DataSet GetBookInfo();

        [OperationContract]
        void Test(MOdelClass md);

        [OperationContract]
        void Test1(string name,string auth,int price,byte[] img);
    }



    [DataContract]
    public class MOdelClass
    {
       [DataMember]
       public string Name { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public byte[] Image { get; set; }


    }
}
