using System;
using System.Collections.Generic; // namespace 가져오는 선언 -> 리스트, 딕셔너리, 스ㅡ택, 큐 등의 제네릭 컬렉션 클래스 제공

public class Solution
{
    public static string[] solution1(string[] players, string[] callings)
    {

        Dictionary<string, int> dict = new Dictionary<string, int>();
        for (int i = 0; i < players.Length; i++)
        {
            dict[players[i]] = i;
            //dict = {{"a",0},{"b",1},{"c",2},{"d",3}}
        }
        foreach (string e in callings)
        {
            //dict 에서의 순위 관련 변경
            int index = dict[e];
            dict[e]--;
            dict[players[index - 1]]++;

            //실질적인 players 배열에서의 순위 변경
            string temp = players[index];
            players[index] = players[index - 1];
            players[index - 1] = temp;
        }
        return players;
    }

    public class Start
    {
        public static void Main()
        {
            string[] players = { "a", "b", "c", "d" };
            string[] callings = { "b", "d", "d" };
            string[] result = Solution.solution1(players, callings);
            Console.WriteLine(string.Join(", ", result));
            /*** 배열은 콘솔 입출력에 바로 적용하면 타입 정보가 출력된다. 
            따라서, 배열을 바로 Console.WriteLine에 적용하려면 배열을 문자열로 변환한다.
            -> Console.WriteLine(string.Join(",",result) 와 같은 방법 사용 ***/
        }
    }
}
