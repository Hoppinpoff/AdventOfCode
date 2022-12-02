List<int> totalCalories = new();
string input = "C:\\Users\\John\\Documents\\GitHub\\AdventOfCode\\InputFile.txt";

using (StreamReader reader = new(input)) {
  string? line;
  int calories = 0;
  while ((line = reader.ReadLine()) != null) {
    if (line != "") {
      calories += int.Parse(line);
    } else {
      totalCalories.Add(calories);
      calories = 0;
    }
  }
}
Console.WriteLine(totalCalories.Max().ToString());
totalCalories.Sort();
totalCalories.Reverse();
int finalAnswer = totalCalories[0] + totalCalories[1] + totalCalories[2];
Console.WriteLine(finalAnswer);

