namespace Stratego.Core
{
    public class Field
    {
        private Terrain _terrain;
        private Pawn _pawn;

        /// <summary>
        /// Terrain on this field.
        /// </summary>
        public Terrain Terrain
        {
            get
            {
                return _terrain;
            }
            set
            {
                _terrain = value;
            }
        }

        /// <summary>
        /// Pawn on this field.
        /// </summary>
        public Pawn Pawn
        {
            get
            {
                return _pawn;
            }
            set
            {
                _pawn = value;
            }
        }
    }
}
