using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MvsProject.BL.Exceptions
{
    public class ProductException:Exception
    {
        public ProductException():base("Default exception")
        {
            
        }

        public ProductException(string message):base(message)
        {
            
        }
    }
}
