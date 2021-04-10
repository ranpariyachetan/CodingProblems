namespace CodingProblems
{
    public class Robot
    {
        //Problem statement : https://aonecode.com/amazon-online-assessment/Robot-Bounded-in-Circle
        public static bool IsCirclePath(string path)
        {
            int x = 0;
            int y = 0;
            int dx = 0;
            int dy = 1;
            int temp;
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
                        break;
                    case 'L':
                        temp = dx;
                        dx = -dy;
                        dy = temp;
                        break;
                }
            }

            return x == 0 && y == 0 || !(dx == 0 && dy == 1);
        }
    }
}