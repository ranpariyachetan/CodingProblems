using System;

namespace CodingProblems
{
    public class Robot
    {
        private const string NORTH = "N";
        private const string SOUTH = "S";
        private const string EAST = "E";
        private const string WEST = "W";
        private const char LEFT = 'L';
        private const char RIGHT = 'R';

        //Problem statement : https://aonecode.com/amazon-online-assessment/Robot-Bounded-in-Circle
        public static bool IsCirclePath(string path)
        {
            int x = 0;
            int y = 0;
            int dx = 0;
            int dy = 1;
            int temp;
            string dir = NORTH;

            Console.WriteLine($"Starting direction: {dir}");
            foreach (var ch in path)
            {
                switch (ch)
                {
                    case 'S':
                        x += dx;
                        y += dy;
                        break;
                    case 'R':
                        temp = dx;
                        dx = dy;
                        dy = -temp;
                        dir = GetNewDirection(dir, ch);
                        Console.WriteLine($"Moved {ch}. Now pointing to : {dir}");
                        break;
                    case 'L':
                        temp = dx;
                        dx = -dy;
                        dy = temp;
                        dir = GetNewDirection(dir, ch);
                        Console.WriteLine($"Moved {ch}. Now pointing to : {dir}");
                        break;
                }
            }

            Console.WriteLine($"Ending direction: {dir}");
            Console.WriteLine($"Same location : {x == 0 && y == 0}");
            Console.WriteLine($"Same Direction : {dx == 0 && dy == 1}");

            return x == 0 && y == 0 || !(dx == 0 && dy == 1);
        }

        private static string GetNewDirection(string currentDirection, char move)
        {
            switch (currentDirection)
            {
                case Robot.NORTH:
                    if (move == LEFT)
                        return WEST;
                    if (move == RIGHT)
                        return EAST;
                    break;
                case SOUTH:
                    if (move == LEFT)
                        return EAST;
                    if (move == RIGHT)
                        return WEST;
                    break;
                case EAST:
                    if (move == LEFT)
                        return NORTH;
                    if (move == RIGHT)
                        return SOUTH;
                    break;
                case WEST:
                    if (move == LEFT)
                        return SOUTH;
                    if (move == RIGHT)
                        return NORTH;
                    break;
                default:
                    return "";
            }
            return "";
        }
    }
}