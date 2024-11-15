using System;

public class Solution
{
	// "mm:ss" 형식의 문자열을 초 단위로 변환
	private static int ToSecond(string timeStr) // "mm:ss"를 timeStr 매개변수
	{
		var parts = timeStr.Split(':'); //parts 문자열 배열에 분,초 저장
		int minutes = int.Parse(parts[0]); //minutes 정수형에 분을 저장하기 위해 Parse 사용
		int seconds = int.Parse(parts[1]);
		return minutes * 60 + seconds; //초로 변환하여 반환
	}

	// 초 단위의 정수형 변수를 "mm:ss" 형식의 문자열로 변환
	private static string ToMmSs(int totalSeconds)
	{
		int minutes = totalSeconds / 60;
		int seconds = totalSeconds % 60;
		return $"{minutes}:{seconds}"; //문자열 보간 사용
	}

	//비디오의 현재 재생 위치 업데이트 & "mm:ss" 반환
	public string UpdateVideoPosition(string video_len, string pos, string op_start, string op_end, string[] commands)
	//매개변수 : 비디오의 전체 길이, 현재 재생 위치, 오프닝 시작 구간, 오프닝 엔딩 구간, 입력 명령어 배열)
	{
		int video_len_sec = ToSecond(video_len);
		int current_Pos = ToSecond(pos);
		int op_Start_Sec = ToSecond(op_start);
		int op_End_Sec = ToSecond(op_end);

		foreach (string command in commands)
		{
			if (command == "prev")
			{
				current_Pos = Math.Max(0, current_Pos - 10);
				//Math.Max : 두 값 중 더 큰 값을 반환
			}
			else if (command == "next")
			{
				current_Pos = Math.Min(video_len_sec, current_Pos + 10);
			}

			if (op_Start_Sec <= current_Pos && current_Pos <= op_End_Sec)
			{
				current_Pos = op_End_Sec;
			}
		}

		return ToMmSs(current_Pos);
	}

	public class Start
	{
		public static void Main()
		{
			Solution solution = new Solution();
			string video_len = "5:30";
			string pos = "1:20";
			string op_start = "0:10";
			string op_end = "0:20";
			string[] commands = { "prev", "next", "prev", "next" };

			string result = solution.UpdateVideoPosition(video_len, pos, op_start, op_end, commands);
			Console.WriteLine(result);

		}
	}

}