using Montana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Game
{
    public class Terrain : IDisplay
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
        /// Can enter to this field.
        /// </summary>
        public bool IsLock { get; set; }

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
