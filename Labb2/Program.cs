
string path = @"levels\level1.txt";
string fullPath = Path.GetFullPath(path);


Console.WriteLine(path);

Console.CursorVisible = false;
GameLoop StartGame = new GameLoop(fullPath);
StartGame.GameRun();

Console.Clear();
Console.WriteLine("Spelet är avslutat");