using System.Collections.Generic;
using System.Linq;
namespace CodingProblems
{
    public class MultiProcessor
    {
        // Problem statement : https://aonecode.com/interview-question/schedule-tasks
        public static int MinimumTimeFoFinish(int[] powers, int tasks)
        {
            var orderedPower = powers.OrderByDescending(i => i);
            int answer = 0;

            foreach (int power in orderedPower)
            {
                tasks -= power;

                int d = power / 2;

                if (power > 0)
                {
                    orderedPower.Append(d);
                }
                answer++;

                if (tasks <= 0)
                {
                    break;
                }
            }

            return answer;
        }

        //Problem statement :   

        public static int RecruitmentCombinations(int[] pms, int[] ses, int[] acms, int[] pmms, int budget)
        {
            var counter = new Dictionary<int, int>();

            for (int i = 0; i < pms.Length; i++)
            {
                for (int j = 0; j < ses.Length; j++)
                {
                    var sum = pms[i] + ses[j];
                    if (counter.ContainsKey(sum))
                    {
                        counter[sum] += 1;
                    }
                    else
                    {
                        counter.Add(sum, 1);
                    }
                }
            }

            int answer = 0;
            for (int i = 0; i < acms.Length; i++)
            {
                for (int j = 0; j < pmms.Length; j++)
                {
                    var sum = acms[i] + pmms[j];

                    for (int k = 0; k < budget - sum + 1; k++)
                    {
                        if (counter.ContainsKey(k))
                        {
                            answer += counter[k];
                        }
                    }
                }
            }

            return answer;
        }
    }
}