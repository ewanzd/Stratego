using Stratego.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class StrategoPlayerManager
    {
        private readonly Guid _id;
        private string _name;
        private string _color;
        private StrategoBenchSetup _benchSetup;
        private StrategoBenchInPlay _benchInPlay;

        /// <summary>
        /// 
        /// </summary>
        public Guid Id {
            get {
                return _id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public StrategoPlayerManager(Guid id) {
            if (id == default(Guid)) {
                throw new ArgumentException("Player need a Guid.", nameof(id));
            }

            _id = id;
        }

        public void SetUnit() {

        }
    }
}
