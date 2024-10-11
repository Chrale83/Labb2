Console.CursorVisible = false;

string path = @"levels\level1.txt";
string fullPath = Path.GetFullPath(path);

GameLoop StartGame = new GameLoop(fullPath);

StartGame.GameRun();

Console.Clear();
Console.WriteLine("Spelet är avslutat");