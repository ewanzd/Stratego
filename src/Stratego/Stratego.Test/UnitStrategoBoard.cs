using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratego.Test
{
    /// <summary>
    /// Test <see cref="Stratego.Core.StrategoBoard"/>.
    /// </summary>
    [TestClass]
    public class UnitStrategoBoard
    {
        StrategoBoard board;

        [TestInitialize]
        public void Init() {
            board = new StrategoBoardGeneratorClassic().DrawBoard();
        }
    }
}
