using TextualRealityExperienceEngine.GameEngine.Interfaces;

namespace TextualRealityExperienceEngine.EscapeGameShared
{
    public interface IEscapeGame
    {
        void InitializeGame();
        IGame Game { get; }
    }
}