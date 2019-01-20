using System;
using TextualRealityExperienceEngine.GameEngine;
using TextualRealityExperienceEngine.GameEngine.EscapeGameLibrary;

namespace TextualRealityExperienceEngine.EscapeTestHarness
{
    static class Program
    {
        private static EscapeGames _gameRegistry = new EscapeGames();
        static void Main(string[] args)
        {
            Console.Clear();
            
            var game = _gameRegistry.GetNextGame();
            
            Console.WriteLine(game.Prologue);
            Console.WriteLine();

            ConsoleEx.WordWrap(game.StartRoom.Description);
            Console.WriteLine();

            while (true)
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                var reply = game.ProcessCommand(command);

                switch (reply.State)
                {
                    case GameStateEnum.Playing:
                        if (!string.IsNullOrEmpty(reply.Reply))
                        {
                            Console.WriteLine();                            
                            ConsoleEx.WordWrap(reply.Reply);
                        }
                        continue;

                    case GameStateEnum.Clearscreen:
                        Console.Clear();
                        continue;

                    case GameStateEnum.Exit:
                        Console.WriteLine();
                        Console.Write(game.ContentManagement.RetrieveContentItem("AreYouSure"));
                        var response = Console.ReadLine();

                        if (response != null && response.ToLower() == "y")
                        {
                            Console.WriteLine();
                            ConsoleEx.WordWrap(game.ContentManagement.RetrieveContentItem("ExitMessage"));

                            Environment.Exit(0);
                        }
                        continue;

                    case GameStateEnum.Score:
                        Console.WriteLine();
                        Console.WriteLine("You have made " + game.NumberOfMoves + " so far.");
                        Console.WriteLine("You score is " + game.Score);
                        Console.WriteLine();
                        continue;

                    case GameStateEnum.Inventory:
                        if (game.Inventory.Count() == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Your inventory is empty.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Inventory");
                            Console.WriteLine("---------");

                            foreach (var i in game.Inventory.GetInventory())
                            {
                                Console.WriteLine("   " + i);
                            }

                            Console.WriteLine();
                        }
                        continue;
                    case GameStateEnum.Help:
                        Console.WriteLine();
                        Console.WriteLine("Game Manual");
                        Console.WriteLine("-----------");
                        Console.WriteLine();
                        ConsoleEx.WordWrap(game.HelpText);
                        continue;
                }
            }
        }
    }
}