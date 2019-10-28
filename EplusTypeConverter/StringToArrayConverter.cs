using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EplusInputConverter
{
    public class StringToArrayConverter : IConverter
    {
        public ICollection Convert(string input)
        {
            return input.Select(character =>(char?) character).ToArray();
        }
    }
}
