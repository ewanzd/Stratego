using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stratego.Data;
using Stratego.Data.Business;
using System;

namespace Stratego.Test
{
    /// <summary>
    /// Test <see cref="Stratego.Core.Test.StrategoGameManager"/>.
    /// </summary>
    [TestClass]
    public class UnitStrategoGameManager
    {
        StrategoGameManager game;

        [TestInitialize]
        public void Init() {
            game = StrategoGameManager.New();
        }

        /// <summary>
        /// Test whether push a event if set new title.
        /// </summary>
        [TestMethod]
        public void TestSetTitle() {
            game.TitleChanged += (obj, e) => { Assert.IsTrue(true); };

            game.Title = "Test Game";
        }

        /// <summary>
        /// Test if the game is ready after set players.
        /// </summary>
        [TestMethod]
        public void TestAddPlayers() {
            var playerOne = new Player() {
                Id = Guid.NewGuid(),
                Name = "PlayerOne"
            };
            var playerTwo = new Player() {
                Id = Guid.NewGuid(),
                Name = "PlayerTwo"
            };

            Assert.IsTrue(game.AddPlayer(playerOne));
            Assert.IsTrue(game.AddPlayer(playerTwo));
            Assert.IsTrue(game.IsReadyToPrep);
        }
    }
}
