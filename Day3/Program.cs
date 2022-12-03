string input = "C:\\Users\\John\\Documents\\GitHub\\AdventOfCode\\InputFile.txt";
int sum = 0;
int sum1 = 0;
Dictionary<char, int> priorities = new();
priorities.Add('a', 1);
priorities.Add('b', 2);
priorities.Add('c', 3);
priorities.Add('d', 4);
priorities.Add('e', 5);
priorities.Add('f', 6);
priorities.Add('g', 7);
priorities.Add('h', 8);
priorities.Add('i', 9);
priorities.Add('j', 10);
priorities.Add('k', 11);
priorities.Add('l', 12);
priorities.Add('m', 13);
priorities.Add('n', 14);
priorities.Add('o', 15);
priorities.Add('p', 16);
priorities.Add('q', 17);
priorities.Add('r', 18);
priorities.Add('s', 19);
priorities.Add('t', 20);
priorities.Add('u', 21);
priorities.Add('v', 22);
priorities.Add('w', 23);
priorities.Add('x', 24);
priorities.Add('y', 25);
priorities.Add('z', 26);
priorities.Add('A', 27);
priorities.Add('B', 28);
priorities.Add('C', 29);
priorities.Add('D', 30);
priorities.Add('E', 31);
priorities.Add('F', 32);
priorities.Add('G', 33);
priorities.Add('H', 34);
priorities.Add('I', 35);
priorities.Add('J', 36);
priorities.Add('K', 37);
priorities.Add('L', 38);
priorities.Add('M', 39);
priorities.Add('N', 40);
priorities.Add('O', 41);
priorities.Add('P', 42);
priorities.Add('Q', 43);
priorities.Add('R', 44);
priorities.Add('S', 45);
priorities.Add('T', 46);
priorities.Add('U', 47);
priorities.Add('V', 48);
priorities.Add('W', 49);
priorities.Add('X', 50);
priorities.Add('Y', 51);
priorities.Add('Z', 52);

using (StreamReader reader = new(input)) {
  string? line;
  while ((line = reader.ReadLine()) != null) {
    string c1 = line.Substring(0, (line.Length / 2));
    string c2 = line.Substring((line.Length / 2), (line.Length / 2));
    foreach (char item in c1) {
      if (c2.Contains(item)) {
        sum += priorities[item];
        break;
      }
    }
  }
}

Console.WriteLine(sum);

using (StreamReader reader = new(input)) {
  string? line;
  while ((line = reader.ReadLine()) != null) {
    string r1 = line;
    string r2 = reader.ReadLine();
    string r3 = reader.ReadLine();
    foreach (char item in r1) {
      if (r2.Contains(item) && r3.Contains(item)) {
        sum1+= priorities[item];
        break;
      }
    }
  }
}

Console.WriteLine(sum1);
