using System;

namespace Stratego.Game
{
    /// <summary>
    /// Main data of one game.
    /// </summary>
    [Serializable]
    public class GameInfo
    {
        public Guid GameId;
        public string Title;
        public DateTime CreateDateTime;
        public DateTime FinishDateTime;
        public GameState GameState;
    }
}
