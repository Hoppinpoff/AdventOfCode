Dictionary<string, int> results = new();
int totalScore = 0;
string input = "C:/Users/jlee/Desktop/adventinput.txt";

using (StreamReader reader = new(input)) {
  string? line;
  string? key;
  while ((line = reader.ReadLine()) != null) {
    key = $"{line[0]}{line[2]}";
    if (results.ContainsKey(key)) {
      totalScore += results[key];
    } else {
      results.Add(key, GetScoreB(key));
      totalScore += results[key];
    }
  }
  Console.WriteLine(totalScore);
}

static int GetScoreA(string key) {
  int score = 0;
  switch (key) {
    case "AY":
      score = 6 + 2; //rock loses to paper
      break;
    case "AX":
      score = 3 + 1; //rock ties with rock
      break;
    case "AZ":
      score = 0 + 3; //rock beats paper
      break;
    case "BY": //paper ties with paper
      score = 3 + 2;
      break;
    case "BX": //paper beats rock
      score = 0 + 1;
      break;
    case "BZ": //paper loses to scissors
      score = 6 + 3;
      break;
    case "CY": //scissors beats paper
      score = 0 + 2;
      break;
    case "CX": //scissors loses to rock
      score = 6 + 1;
      break;
    case "CZ": //scissors ties scissors
      score = 3 + 3;
      break;
    default:
      break;
  }
  return score;
}

static int GetScoreB(string key) {
  int score = 0;
  switch (key) {
    case "AY":
      score = 3 + 1; 
      break;
    case "AX":
      score = 0 + 3; 
      break;
    case "AZ":
      score = 6 + 2; 
      break;
    case "BY": 
      score = 3 + 2;
      break;
    case "BX": 
      score = 0 + 1;
      break;
    case "BZ": 
      score = 6 + 3;
      break;
    case "CY": 
      score = 3 + 3;
      break;
    case "CX": 
      score = 0 + 2;
      break;
    case "CZ": 
      score = 6 + 1;
      break;
    default:
      break;
  }
  return score;
}