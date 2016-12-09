using Montana;

namespace Stratego.Core
{
    public class UnitInfo : IDisplay
    {
        ///// <summary>
        ///// Id of member.
        ///// </summary>
        //public int Id { get; set; }

        /// <summary>
        /// Unique name of member.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Key of name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Key of description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Rank of unit.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Value of unit for AI.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Max count to place.
        /// </summary>
        public int MaxAvailable { get; set; }

        /// <summary>
        /// Move type (none, diagonal, cross, abroad).
        /// </summary>
        public MoveType MoveType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SpecialSkill SpecialUnit { get; set; }

        /// <summary>
        /// Get type name of member.
        /// </summary>
        /// <returns>The type name of member.</returns>
        public override string ToString()
        {
            return Type;
        }
    }
}
