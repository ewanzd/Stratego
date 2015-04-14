using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class Unit : IDisplay
    {
        /// <summary>
        /// Id of member.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Unique name of member.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Display name of member.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display description of member.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The power of unit.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Value of unit for AI.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Range of unit.
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Move type (none, diagonal, cross, abroad).
        /// </summary>
        public MoveType MoveType { get; set; }

        /// <summary>
        /// Get type name of member.
        /// </summary>
        /// <returns>The type name of member.</returns>
        public override string ToString()
        {
            return TypeName;
        }
    }
}
