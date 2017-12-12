using System;

namespace Advent_Of_Code_2017
{
    public static class Program
    {
        public static void Main( string[] args )
        {
            IDay day = new Day3();

            Console.WriteLine( $"{day.ToString()} solution: {day.Solve( "289326" )}" );
            Console.WriteLine( $"{day.ToString()} advanced solution: {day.SolveAdvanced( "289326" )}" );
            Console.ReadKey();
        }
    }
}
