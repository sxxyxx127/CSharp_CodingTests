using System;


public class Solution
{
    public static string Cards(string[] cards1, string[] cards2, string[] goal)
    {
        int c1 = 0;
        int c2 = 0;

        for(int i = 0; i <goal.Length; i++)
        {
            if(c1<cards1.Length)
            {
                if(cards1[c1] == goal[i])
                {
                    c1++;
                    continue;
                }
            }
            if(c2<cards2.Length)
            {
                if (cards2[c2] == goal[i])
                {
                    c2++;
                    continue;
                }
            }
            return "No";

        }
        return "Yes";
        
    }

    public class Start
    {
        public static void Main()
        {
            string[] cards1 = {"i","drink","water"};
            string[] cards2 = {"want","to"};
            string[] goal = {"i","want","to","drink","water"};
            string result = Solution.Cards(cards1, cards2, goal);
            Console.WriteLine(result);
        }
    }

}