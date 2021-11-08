using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppToTest
{
   public class BusinessLogic
    {
        public string korellenorzes(int kor) => kor >= 18
                ? "Nagykorú"
                : "Kiskorú";

        public string vegrehajtas(bool b)
        {
            if (b)
            {
                vegrehajtandoFeladat();
                return "OK";
            }

            return "FAIL";
        }
        public void vegrehajtandoFeladat() { }
    }


    
}
