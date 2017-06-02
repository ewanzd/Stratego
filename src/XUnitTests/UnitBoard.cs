using Montana;
using Xunit;

namespace Stratego.Test
{
    public class UnitBoard
    {
        [Fact]
        public void InitBoardTest() {
            Board<int> board = new Board<int>(10, 10);

            Assert.True(board.Width == 10);
            Assert.True(board.Height == 10);
        }
    }
}
