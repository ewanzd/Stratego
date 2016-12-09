namespace Stratego.Core
{
    public class Terrain
    {
        private string _typeName;
        private bool _lock;

        /// <summary>
        /// Unique name of member.
        /// </summary>
        public string TypeName {
            get { return _typeName; }
            set { _typeName = value; }
        }

        ///// <summary>
        ///// Display name of member.
        ///// </summary>
        //public string DisplayName { get; set; }

        ///// <summary>
        ///// Display description of member.
        ///// </summary>
        //public string Description { get; set; }

        /// <summary>
        /// Can enter to this field.
        /// </summary>
        public bool IsLock {
            get { return _lock; }
            set { _lock = value; }
        }

        ///// <summary>
        ///// Get type name of member.
        ///// </summary>
        ///// <returns>The type name of member.</returns>
        //public override string ToString()
        //{
        //    return TypeName;
        //}
    }
}
