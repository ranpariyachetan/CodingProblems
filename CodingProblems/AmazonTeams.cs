using System.Collections.Generic;
namespace CodingProblems
{
    public class AmazonTeams
    {
        public static int GetTeams(List<int> skills, int teamSize, int maxDiff)
        {
            var answer = 0;
            var i = 0;

            skills.Sort();
            while (i <= skills.Count - teamSize)
            {
                if (skills[i + teamSize - 1] - skills[i] <= maxDiff)
                {
                    answer += 1;
                    i += teamSize;
                }
                else
                {
                    i += 1;
                }
            }
            return answer;
        }
    }
}