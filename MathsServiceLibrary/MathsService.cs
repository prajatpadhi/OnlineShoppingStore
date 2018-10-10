using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MathsService : IBasicMath
    {
        public int Add(int a, int b)
        {
            System.Threading.Thread.Sleep(5000);
            return a + b;
        }

        
    }
}
