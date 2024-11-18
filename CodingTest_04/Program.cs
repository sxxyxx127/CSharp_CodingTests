using System;

public class Solution
{
    // 덧칠 횟수를 계산하는 메서드
    public int Solution_1(int n, int m, int[] section)
    {
        int result = 0; // 총 덧칠 횟수
        int temp = 0; // 현재 덮을 수 있는 마지막 위치

        for (int i = 0; i < section.Length; i++)
        {
            if (section[i] > temp)
            {
                temp = section[i] + m - 1; // 새로운 덮는 범위 설정
                result++; // 덧칠 횟수 증가
            }
        }
        return result;
    }

    // 메인 실행 메서드
    public static void Main(string[] args)
    {
        int n = 10;
        int m = 3;
        int[] section = { 2, 3, 8 };

        // Solution 클래스 인스턴스 생성
        Solution solution = new Solution();

        // Solution_1 호출 및 결과 출력
        int answer = solution.Solution_1(n, m, section);

        Console.WriteLine("최소 덧칠 횟수: " + answer);
    }
}
