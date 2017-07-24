using System;

namespace Stratego.Core.Def
{
    /// <summary>
    /// Special skills.
    /// </summary>
    [Flags]
    public enum SpecialSkill
    {
        None    = 0,
        Flag    = 1 << 0,
        Bomb    = 1 << 1,
        Miner   = 1 << 2,
        Marshal = 1 << 3,
        Scout   = 1 << 4,
        Spion   = 1 << 5
    }
}
