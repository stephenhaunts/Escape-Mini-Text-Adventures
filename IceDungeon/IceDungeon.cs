using System;
using TextualRealityExperienceEngine.GameEngine;
using TextualRealityExperienceEngine.GameEngine.Interfaces;
using TextualRealityExperienceEngine.GameEngine.Synonyms;

namespace TextualRealityExperienceEngine.Game.IceDungeon
{
    class IceDungeon : Room
    {    
        public IceDungeon (IGame game) : base(game)
        {
            InitContentManagement();
            Description = Game.ContentManagement.RetrieveContentItem("DungeonDescription");
            Name = Game.ContentManagement.RetrieveContentItem("DungeonName");

            LightsOn = true;
        }

        private void InitContentManagement()
        {
            Game.ContentManagement.AddContentItem("DungeonName", "Ice Dungeon");
            Game.ContentManagement.AddContentItem("DungeonDescription", "You are standing in a dark dungeon CM.");
            Game.ContentManagement.AddContentItem("DungeonProfanity", "There is no need to be rude, the walls have ears.");
            Game.ContentManagement.AddContentItem("DungeonDoormat", "It's a doormat where people wipe their feet. On it is written 'There is no place like 10.0.0.1'.");
            Game.ContentManagement.AddContentItem("DungeonNoHint", "There are no hints available at the moment.");
        }

        public override string ProcessCommand(ICommand command)
        {
            if (command.ProfanityDetected)
            {
                return Game.ContentManagement.RetrieveContentItem("DungeonProfanity");
            }
            
            switch (command.Verb)
            {                   
                case VerbCodes.Look:
                    switch (command.Noun)
                    {                       
                        case "doormat":
                            return Game.ContentManagement.RetrieveContentItem("DungeonDoormat");
                    }

                    break;
               
                case VerbCodes.NoCommand:
                    break;
                case VerbCodes.Go:
                    break;
                case VerbCodes.Drop:
                    break;
                case VerbCodes.Take:
                    break;
                case VerbCodes.Use:
                    break;
                case VerbCodes.Hint:
                    return Game.ContentManagement.RetrieveContentItem("DungeonNoHint");
                  
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var reply = base.ProcessCommand(command);
            return reply;
        }
    }
}