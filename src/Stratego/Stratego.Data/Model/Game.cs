using System;

namespace Stratego.Data
{
    [Serializable]
    public class Game
    {
        public Guid Id;
        public string Title;
        public DateTime Created_Date;
        public DateTime Finished_Date;
        public Player Player_1;
        public Player Player_2;
        public Guid File_Id; // board and listOfMoves
    }
}
