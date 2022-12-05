using System.Text;

string input = "Input.txt";
var stacks = new List<Stack<char>>();
var CrateMover9001 = new Stack<char>();

CreateStacks();

using (StreamReader reader = new(input)) {
  string? line;
  while ((line = reader.ReadLine()) != null) {
    var (quantity, fromStack, toStack) = Instructions(line);
    for (int i = 0; i < quantity; i++) {
      CrateMover9001.Push(stacks[fromStack].Pop());
    }
    for (int i = 0; i < quantity; i++) {
      stacks[toStack].Push(CrateMover9001.Pop());
    }
  }
}

var builder = new StringBuilder();
foreach (Stack<Char> stack in stacks) {
  builder.Append(stack.Peek());
}
Console.WriteLine(builder.ToString());

static (int quantity, int fromStack, int toStack) Instructions(string line) {
  string[] info = line.Split(new string[] { "from", "to" }, StringSplitOptions.None);
  int quantity = int.Parse(info[0].Replace("move", "").Trim());
  int fromStack = int.Parse(info[1].Trim())-1;
  int toStack = int.Parse(info[2].Trim())-1;
  return (quantity, fromStack, toStack);

}

void CreateStacks() {
  var s1 = new Stack<char>();
  s1.Push('Z');
  s1.Push('J');
  s1.Push('G');
  stacks.Add(s1);
  var s2 = new Stack<char>();
  s2.Push('Q');
  s2.Push('L');
  s2.Push('R');
  s2.Push('P');
  s2.Push('W');
  s2.Push('F');
  s2.Push('V');
  s2.Push('C');
  stacks.Add(s2);
  var s3 = new Stack<char>();
  s3.Push('F');
  s3.Push('P');
  s3.Push('M');
  s3.Push('C');
  s3.Push('L');
  s3.Push('G');
  s3.Push('R');
  stacks.Add(s3);
  var s4 = new Stack<char>();
  s4.Push('L');
  s4.Push('F');
  s4.Push('B');
  s4.Push('W');
  s4.Push('P');
  s4.Push('H');
  s4.Push('M');
  stacks.Add(s4);
  var s5 = new Stack<char>();
  s5.Push('G');
  s5.Push('C');
  s5.Push('F');
  s5.Push('S');
  s5.Push('V');
  s5.Push('Q');
  stacks.Add(s5);
  var s6 = new Stack<char>();
  s6.Push('W');
  s6.Push('H');
  s6.Push('J');
  s6.Push('Z');
  s6.Push('M');
  s6.Push('Q');
  s6.Push('T');
  s6.Push('L');
  stacks.Add(s6);
  var s7 = new Stack<char>();
  s7.Push('H');
  s7.Push('F');
  s7.Push('S');
  s7.Push('B');
  s7.Push('V');
  stacks.Add(s7);
  var s8 = new Stack<char>();
  s8.Push('F');
  s8.Push('J');
  s8.Push('Z');
  s8.Push('S');
  stacks.Add(s8);
  var s9 = new Stack<char>();
  s9.Push('M');
  s9.Push('C');
  s9.Push('D');
  s9.Push('P');
  s9.Push('F');
  s9.Push('H');
  s9.Push('B');
  s9.Push('T');
  stacks.Add(s9);
}