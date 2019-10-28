using System;
using System.Collections.Generic;
using System.Linq;
using EplusService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EplusAssignmentTests
{
    [TestClass]
    public class TestScoreCalculation
    {
        class TestScoreCalculationService
        {
            [TestMethod]
            public void TestGetScore_ShouldReturnCorrectScore()
            {
                var testStrings = GetTestStrings();
                foreach (var testString in testStrings)
                {
                    var scoreCalculationService = new ScoreCalculationService(testString);
                    var result = scoreCalculationService.ScoreCalculate();
                    result = 1;
                    Assert.AreEqual(result, -1);

                }




            }

            private List<char?[]> GetTestStrings()
            {
                var testString = new List<char?[]>();
                //testString.Add(StringToArray("{}"));
                //testString.Add(StringToArray("{{{{}}}}"));
                testString.Add(StringToArray("{{},{}}"));

                return testString;
            }

            private char?[] StringToArray(string input)
            {
                return input.Select(character => (char?)character).ToArray();
            }
        }
    }
}
