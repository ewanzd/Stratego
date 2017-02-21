namespace Stratego.Core
{
    public class Field
    {
        private bool _isLocked;
        private Pawn _pawn;

        /// <summary>
        /// Field is locked.
        /// </summary>
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
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
