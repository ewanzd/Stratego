namespace Stratego.Game
{
    public class Terrain
    {
        // readonly?

        /// <summary>
        /// Unique name of member.
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Display name of member.
        /// </summary>
        public string DisplayName { get; set; }

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
