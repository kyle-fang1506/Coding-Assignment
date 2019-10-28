using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EplusService
{
    public interface ICalculationService
    {
        char?[] Input { get; set; }
        int ScoreCalculate();
    }
}
