using System;

namespace Montana
{
    /// <summary>
    /// o = None
    /// 1 = Diagonal
    /// 2 = Cross
    /// 3 = Abroad
    /// </summary>
    [Flags]
    public enum MoveType
    {
        None = 0,
        Diagonal = 1 << 0,
        Cross = 1 << 1,

        Abroad = Diagonal | Cross
    }
}
