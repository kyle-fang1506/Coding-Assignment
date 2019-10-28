using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EplusInputConverter;
using EplusService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EplusTests
{
    [TestClass]
    public class ScoreCalculationTests
    {
        //Here I will only test the ScoreCalculate method 
        //since this is the only public method in the ScoreCalculationService class
        //private methods can be tested by Refection, however it is unnecessary and a bad practice
        [TestMethod]
        public void TestScoreCalcuate()
        {
            foreach(var item in stringDictionary)
            {
                var arr = item.Key.Select(c => (char?)c).ToArray();              
                var service= new ScoreCalculationService();
                service.Input=arr;
                int score = service.ScoreCalculate();
                Assert.AreEqual(score, item.Value);

            }
        }


        static Dictionary<string, int> stringDictionary;
        static ScoreCalculationTests()
        {
            stringDictionary = new Dictionary<string, int>()
            {
                //valid input cases
                {"",0 },
                {"{}", 1 },
                {"{{{}}}", 6 },
                {"{a{aa{aaa}aaaa}aaaaa}", 6 },
                {"{{},{}}", 5 },
                {"{{{},{},{{}}}}",16 },
                {"{{<ab>},{<ab>},{<ab>},{<ab>}}",9},
                {"{{<!!>},{<!!>},{<!!>},{<!!>}}",9},
                {"{{<a!>},{<a!>},{<a!>},{<ab>}}",3 },

                //invalid input cases
                {"a",-1 },
                {"{!}", -1 },
                {"{},{}", -1 },
                {"{}}",-1 },
                {"{{}",-1 },
                {"a{}",-1 },
                {"{}a",-1 },
                {"{>}}",-1 },
             
            };
        }

    }
}
