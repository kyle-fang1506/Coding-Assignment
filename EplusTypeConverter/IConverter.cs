using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EplusInputConverter
{
    public interface IConverter
    {
         ICollection Convert(string input);
       
    }
}
