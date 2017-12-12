using System.Collections.Generic;
using NUnit.Framework;

namespace Advent_Of_Code_2017
{
    public interface IDay
    {
        string Solve( string input );

        string SolveAdvanced( string input );
    }

    [TestFixture]
    public class DayTests
    {
        [TestCaseSource( nameof( SolveTestCases ) )]
        public void Solve_ShouldReturnCorrectValue( IDay day, string input, string expected )
        {
            Assert.That( day.Solve( input ), Is.EqualTo( expected ) );
        }

        [TestCaseSource( nameof( SolveAdvancedTestCases ) )]
        public void SolveAdvanced_ShouldReturnCorrectValue( IDay day, string input, string expected )
        {
            Assert.That( day.SolveAdvanced( input ), Is.EqualTo( expected ) );
        }

        public static IEnumerable<object[]> SolveTestCases()
        {
            yield return new object[] { new Day1(), "1122", "3" };
            yield return new object[] { new Day1(), "1111", "4" };
            yield return new object[] { new Day1(), "1234", "0" };
            yield return new object[] { new Day1(), "91212129", "9" };

            yield return new object[] { new Day2(), "5	1	9	5\r\n7	5	3\r\n2	4	6	8", "18" };

            yield return new object[] { new Day3(), "1", "0" };
            yield return new object[] { new Day3(), "12", "3" };
            yield return new object[] { new Day3(), "23", "2" };
            yield return new object[] { new Day3(), "1024", "31" };
        }

        public static IEnumerable<object[]> SolveAdvancedTestCases()
        {
            yield return new object[] { new Day1(), "1212", "6" };
            yield return new object[] { new Day1(), "1221", "0" };
            yield return new object[] { new Day1(), "123425", "4" };
            yield return new object[] { new Day1(), "123123", "12" };
            yield return new object[] { new Day1(), "12131415", "4" };

            yield return new object[] { new Day2(), "5	9	2	8\r\n9	4	7	3\r\n3	8	6	5", "9" };

            yield return new object[] { new Day3(), "10", "11" };
            yield return new object[] { new Day3(), "30", "54" };
            yield return new object[] { new Day3(), "133", "142" };
            yield return new object[] { new Day3(), "361", "362" };
            yield return new object[] { new Day3(), "930", "931" };
            yield return new object[] { new Day3(), "290000", "295229" };
        }
    }
}
