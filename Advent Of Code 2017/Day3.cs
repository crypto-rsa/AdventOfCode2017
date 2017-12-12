using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_Of_Code_2017
{
    public class Day3 : IDay
    {
        public override string ToString() => "Day 3";

        public string Solve( string input )
        {
            long number = long.Parse( input );
            if( number == 1 )
                return "0";

            long square = (long) Math.Sqrt( number );

            if( square % 2 == 0 )
            {
                square--;
            }

            long layer = square / 2 + 1;
            long remainder = number - square * square - 1;
            long offset = remainder % (2 * layer);
            long distance = layer + Math.Abs( -layer + 1 + offset );

            return distance.ToString();
        }

        public string SolveAdvanced( string input )
        {
            int number = int.Parse( input );
            var values = new List<long>( number ) { 0, 1, 1, 2, 4, 5, 10, 11, 23, 25 };

            if( values.Any( n => n > number ) )
                return values.First( n => n > number ).ToString();

            int layer = 2;
            int prevSquare = 9;
            int nextSquare = 25;
            int nextIndex = 10;
            int nextIndexBelow = 2;
            int nextCorner = 13;

            while( values.Last() <= number )
            {
                long nextSum = values[nextIndex - 1];

                if( nextIndex == prevSquare + 1 || (nextIndex == nextCorner && nextCorner != nextSquare) )
                {
                    // start of next layer or a corner
                    nextSum += values[nextIndexBelow];
                }
                else if( nextIndex == prevSquare + 2 )
                {
                    nextSum += values[prevSquare];
                    nextSum += values[nextIndexBelow];
                    nextSum += values[nextIndexBelow + 1];

                    nextIndexBelow++;
                }
                else if( nextIndex == nextSquare )
                {
                    nextSum += values[prevSquare];
                    nextSum += values[prevSquare + 1];
                }
                else if( nextIndex == nextCorner - 1 && nextCorner != nextSquare )
                {
                    nextSum += values[nextIndexBelow - 1];
                    nextSum += values[nextIndexBelow];
                }
                else if( nextIndex == nextCorner - 2 * layer + 1 )
                {
                    nextSum += values[nextIndex - 2];
                    nextSum += values[nextIndexBelow];
                    nextSum += values[nextIndexBelow + 1];

                    nextIndexBelow++;
                }
                else
                {
                    nextSum += values[nextIndexBelow - 1];
                    nextSum += values[nextIndexBelow];
                    nextSum += values[nextIndexBelow + 1];

                    nextIndexBelow++;
                }

                if( nextIndex == nextSquare )
                {
                    nextIndexBelow = prevSquare + 1;
                    prevSquare = nextSquare;
                    nextSquare += 8 * (layer + 1);
                    layer++;
                    nextCorner = prevSquare + 2 * layer;
                }
                else if( nextIndex == nextCorner )
                {
                    nextCorner += 2 * layer;
                }

                values.Add( nextSum );
                nextIndex++;
            }

            return values.Last().ToString();
        }
    }
}
