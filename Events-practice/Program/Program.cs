using Game;

var game = new Game.Game(File.ReadAllText("./map.txt"));

game.PrintMap();

game.MoveDown();

game.PrintMap();