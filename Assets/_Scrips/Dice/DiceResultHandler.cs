using UnityEngine;

public class DiceResultHandler
{
    private PlayerPiece piece;

    public DiceResultHandler(PlayerPiece piece)
    {
        this.piece = piece;
    }

    public void HandleResult(int diceValue)
    {
        piece.MoveStep(diceValue);
    }
}
