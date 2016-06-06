using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


public class ModelClass
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public byte[] Image { get; set; }
    public int Price { get; set; }
}
