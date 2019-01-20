using TextualRealityExperienceEngine.EscapeGameShared;
using TextualRealityExperienceEngine.GameEngine.Interfaces;

namespace TextualRealityExperienceEngine.Game.IceDungeon
{
    public class IceDungeonGame : IEscapeGame
    {
        private IceDungeon _iceDungeon;
        public IGame Game { get; private set; }

        public IceDungeonGame()
        {
            InitializeGame();
        }
        
        public void InitializeGame()
        {
            Game = new GameEngine.Game();
            
            InitializeGameContentManagement();

            Game.Prologue = Game.ContentManagement.RetrieveContentItem("Prologue");
            _iceDungeon = new IceDungeon(Game);

            Game.Parser.EnableProfanityFilter = true;
            Game.StartRoom = _iceDungeon;
            Game.CurrentRoom = _iceDungeon;

            Game.Parser.Nouns.Add("doormat", "doormat");
            Game.Parser.Nouns.Add("mat", "doormat");
         }

        private void InitializeGameContentManagement()
        {
            Game.ContentManagement.AddContentItem("HelpText", "Your aim is to find the treasure that is hidden somewhere in the house. \r\nYou need to type commands into the game to control the player.");
            Game.ContentManagement.AddContentItem("AreYouSure", "Are you sure? (y/n) : ");
            Game.ContentManagement.AddContentItem("ExitMessage", "Have it your way.. You spontaneously combust and depart this mortal coil in a puff of smoke....");            
            Game.ContentManagement.AddContentItem("Prologue", "This is the CM prologue.");
            
        }
    }
}