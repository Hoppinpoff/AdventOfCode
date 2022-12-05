string input = "C:\\Users\\John\\Documents\\GitHub\\AdventOfCode\\InputFile.txt";
List<int> elf1 = new();
List<int> elf2 = new();
bool contained = false;
bool overlap = false;
int containedCount = 0;
int overlapCount = 0;

using (StreamReader reader = new(input)) {
  string? line;
  while ((line = reader.ReadLine()) != null) {
    elf1.Clear();
    elf2.Clear();
    string[] elves = line.Split(',');
    string[] elf1range = elves[0].Split('-');
    string[] elf2range = elves[1].Split('-');

    for (int i = int.Parse(elf1range[0]); i <= int.Parse(elf1range[1]); i++) {
      elf1.Add(i);
    }
    for (int i = int.Parse(elf2range[0]); i <= int.Parse(elf2range[1]); i++) {
      elf2.Add(i);
    }

    if (elf2.Count > elf1.Count) {
      foreach (int task in elf1) {
        if (!elf2.Contains(task)) {
          contained = false;
          break;
        } else {
          contained = true;
        }
      }
    } else {
      foreach (int task in elf2) {
        if (!elf1.Contains(task)) {
          contained = false;
          break;
        } else {
          contained = true;
        }
      }
    }

    if (elf2.Count > elf1.Count) {
      foreach (int task in elf1) {
        if (elf2.Contains(task)) {
          overlap = true;
          break;
        } else {
          overlap = false;
        }
      }
    } else {
      foreach (int task in elf2) {
        if (elf1.Contains(task)) {
          overlap = true;
          break;
        } else {
          overlap = false;
        }
      }
    }

    if (contained) {
      containedCount += 1;
    }
    if (overlap) {
      overlapCount += 1;
    }
  }
}


Console.WriteLine(containedCount);
Console.WriteLine(overlapCount);