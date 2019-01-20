using System;
using TextualRealityExperienceEngine.GameEngine;
using TextualRealityExperienceEngine.GameEngine.Interfaces;
using TextualRealityExperienceEngine.GameEngine.Synonyms;

namespace TextualRealityExperienceEngine.EscapeGameLibrary.IceDungeon
{
    
    class IceDungeon : Room
    {    
        public IceDungeon(string name, string description, IGame game) : base(name, description, game)
        {
           
        }

        public override string ProcessCommand(ICommand command)
        {
            if (command.ProfanityDetected)
            {
                return "There is no need to be rude.";
            }
            
            switch (command.Verb)
            {                   
                case VerbCodes.Look:
                    switch (command.Noun)
                    {                       
                        case "doormat":
                            return "It's a doormat where people wipe their feet. On it is written 'There is no place like 10.0.0.1'.";
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
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var reply = base.ProcessCommand(command);
            return reply;
        }
    }
    
    public class IceDungeonGame : Game
    {
        private readonly IceDungeon _iceDungeon;
        
        public IceDungeonGame()
        {
            Prologue = Prologue;

            _iceDungeon = new IceDungeon("Dungeon", "You are sitting in a very cold dungeon", this);
           
            StartRoom = _iceDungeon;
            CurrentRoom = _iceDungeon;
        }
    }
}