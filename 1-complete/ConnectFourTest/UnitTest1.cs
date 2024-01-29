namespace ConnectFourTest;
using ConnectFour;

[TestClass]
public class UnitTest1
{
  [TestMethod]
  public void TestMethod1()
  {
    GameState State = new();
    State.ResetBoard();

    {
      var col = 0;
      var player = State.PlayerTurn;
      var turn = State.CurrentTurn;
      var landingRow = State.PlayPiece(col);
      var result = $"player{player} col{col} drop{landingRow}";
      Console.WriteLine(result);
    }

    {
      var col = 0;
      var player = State.PlayerTurn;
      var turn = State.CurrentTurn;
      var landingRow = State.PlayPiece(col);
      var result = $"player{player} col{col} drop{landingRow}";
      Console.WriteLine(result);
    }

    {
      var winner = State.CheckForWin();
      Console.WriteLine(winner);
    }
  }
}