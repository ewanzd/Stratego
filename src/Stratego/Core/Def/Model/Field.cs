namespace Stratego.Core.Def
{
    public class Field
    {
        private bool _isLocked;
        private Pawn _pawn;

        public bool IsLocked { get => _isLocked; set => _isLocked = value; }
        public Pawn Pawn { get => _pawn; set => _pawn = value; }
    }
}
