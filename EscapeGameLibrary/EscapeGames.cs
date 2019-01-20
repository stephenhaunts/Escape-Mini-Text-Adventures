using System.Collections.Generic;
using TextualRealityExperienceEngine.EscapeGameShared;
using TextualRealityExperienceEngine.Game.IceDungeon;
using TextualRealityExperienceEngine.GameEngine.Interfaces;

namespace TextualRealityExperienceEngine.GameEngine.EscapeGameLibrary
{
    public class EscapeGames
    {
        private Dictionary<string, IEscapeGame> _easyGames = new Dictionary<string,IEscapeGame>();
        private Dictionary<string, IEscapeGame> _mediumGames = new Dictionary<string,IEscapeGame>();
        private Dictionary<string, IEscapeGame> _hardGames = new Dictionary<string,IEscapeGame>();

        public EscapeGames()
        {
            _easyGames.Add("Ice Dungeon", new IceDungeonGame());
        }

        public IGame GetNextGame()
        {
            return _easyGames["Ice Dungeon"].Game;
        }

    }
}