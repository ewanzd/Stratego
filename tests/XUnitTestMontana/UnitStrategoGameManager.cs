using Stratego.Data.Business;
using Stratego.Data.Def;
using System;
using Xunit;

namespace XUnitTestMontana
{
    /// <summary>
    /// Test <see cref="Stratego.Core.Test.StrategoGameManager"/>.
    /// </summary>
    public class UnitStrategoGameManager
    {
        StrategoGameManager game;

        public void Init()
        {
            game = StrategoGameManager.New();
        }

        /// <summary>
        /// Test whether push a event if set new title.
        /// </summary>
        [Fact]
        public void SetTitleTest()
        {
            game.TitleChanged += (obj, e) => { Assert.True(true); };

            game.Title = "Test Game";
        }

        /// <summary>
        /// Test if the game is ready after set players.
        /// </summary>
        [Fact]
        public void AddPlayersTest()
        {
            var playerOne = new Player() {
                Id = Guid.NewGuid(),
                Name = "PlayerOne"
            };
            var playerTwo = new Player() {
                Id = Guid.NewGuid(),
                Name = "PlayerTwo"
            };

            Assert.True(game.AddPlayer(playerOne));
            Assert.True(game.AddPlayer(playerTwo));
            Assert.True(game.IsReadyToPrep);
        }
    }
}
