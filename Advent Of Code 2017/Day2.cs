using System;
using System.Linq;

namespace Advent_Of_Code_2017
{
    public class Day2 : IDay
    {
        public override string ToString() => "Day 2";

        public string Solve( string input )
        {
            var lines = input.Split( new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries );
            var sum = lines.Sum( l =>
            {
                var numbers = l.Split( '\t' ).Select( s => int.Parse( s ) ).ToArray();
                return (numbers.Max() - numbers.Min());
            } );

            return sum.ToString();
        }

        public string SolveAdvanced( string input )
        {
            var lines = input.Split( new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries );
            var sum = lines.Sum( l =>
            {
                var numbers = l.Split( '\t' ).Select( s => int.Parse( s ) ).ToArray();
                return Enumerable.Range( 0, numbers.Length ).Sum( i => Enumerable.Range( 0, numbers.Length ).Sum( j => i != j && numbers[i] % numbers[j] == 0 ? numbers[i] / numbers[j] : 0 ) );
            } );

            return sum.ToString();
        }
    }
}
