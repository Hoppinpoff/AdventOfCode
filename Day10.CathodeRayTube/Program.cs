using System.Runtime.CompilerServices;
using System.Text;

string rawInput = "noop\r\nnoop\r\nnoop\r\naddx 6\r\naddx -1\r\nnoop\r\naddx 5\r\nnoop\r\nnoop\r\naddx -12\r\naddx 19\r\naddx -1\r\nnoop\r\naddx 4\r\naddx -11\r\naddx 16\r\nnoop\r\nnoop\r\naddx 5\r\naddx 3\r\naddx -2\r\naddx 4\r\nnoop\r\nnoop\r\nnoop\r\naddx -37\r\nnoop\r\naddx 3\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 10\r\naddx -9\r\nnoop\r\naddx 1\r\naddx 4\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 5\r\naddx -40\r\naddx 25\r\naddx -22\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 3\r\naddx -2\r\nnoop\r\naddx 23\r\naddx -18\r\naddx 2\r\nnoop\r\nnoop\r\naddx 7\r\nnoop\r\nnoop\r\naddx 5\r\nnoop\r\nnoop\r\nnoop\r\naddx 1\r\naddx 2\r\naddx 5\r\naddx -40\r\naddx 3\r\naddx 8\r\naddx -4\r\naddx 1\r\naddx 4\r\nnoop\r\nnoop\r\nnoop\r\naddx -8\r\nnoop\r\naddx 16\r\naddx 2\r\naddx 4\r\naddx 1\r\nnoop\r\naddx -17\r\naddx 18\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx 1\r\naddx -11\r\naddx -27\r\naddx 17\r\naddx -10\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx 7\r\nnoop\r\naddx -2\r\nnoop\r\naddx 3\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 2\r\nnoop\r\naddx 3\r\naddx 2\r\naddx 5\r\naddx 2\r\naddx -5\r\naddx -2\r\naddx -30\r\naddx 14\r\naddx -7\r\naddx 22\r\naddx -21\r\naddx 2\r\naddx 6\r\naddx 2\r\naddx -1\r\nnoop\r\naddx 8\r\naddx -3\r\nnoop\r\naddx 5\r\naddx 1\r\naddx 4\r\nnoop\r\naddx 3\r\naddx -2\r\naddx 2\r\naddx -11\r\nnoop\r\nnoop\r\nnoop\r\n";
string[] input = rawInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine(Day10.Part1(input));
Console.ReadLine();
Console.Clear();
Day10.Part2(input);

public static class Day10 {
  public static int Part1(string[] input) {
    var cycles = new List<int>();
    int xRegister = 1;

    for (int i = 0; i < input.Length; i++) {
      var command = input[i];
      cycles.ProcessCycle(command, ref xRegister);
    }

    int[] tests = { 20, 60, 100, 140, 180, 220 };
    int answer = 0;
    foreach (int item in tests) {
      answer += item * cycles[item - 1];
    }

    return answer;
  }

  public static void Part2(string[] input) {
    var cycles = new List<int>();
    int xRegister = 1;

    for (int i = 0; i < input.Length; i++) {
      var command = input[i];
      cycles.ProcessCycle(command, ref xRegister);
    }

    var crt = new StringBuilder();
    for (int i = 0; i < 6; i++) {
      for (int j = 40*i; j < 40*(i+1); j++) {
        if (cycles[j] - 1 == j-40*i || cycles[j] == j-40*i || cycles[j] + 1 == j-40*i) {
          crt.Append('#');
        } else {
          crt.Append('.');
        }
      }
    }
    var crtString = crt.ToString();

    Console.WriteLine(crtString.Substring(0, 40));
    Console.WriteLine(crtString.Substring(40, 40));
    Console.WriteLine(crtString.Substring(80, 40));
    Console.WriteLine(crtString.Substring(120, 40));
    Console.WriteLine(crtString.Substring(160, 40));
    Console.WriteLine(crtString.Substring(200, 40));
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ProcessCycle(this List<int> set, string command, ref int x) {
    string instruction = command.Substring(0, 4);
    switch (instruction) {
      case "noop":
        set.Add(x);
        break;
      case "addx":
        int number = int.Parse(command[5..]);
        set.Add(x);
        set.Add(x);
        x += number;
        break;
    }
  }
}
