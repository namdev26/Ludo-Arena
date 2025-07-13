using System.Collections.Generic;
[System.Serializable]
public class Team
{
    public PlayerColor teamColor;
    public List<PlayerPiece> teamMembers = new List<PlayerPiece>();

    public Team(PlayerColor color)
    {
        teamColor = color;
    }

    public bool HasRemainingPieces()
    {
        // check ve chuong
        return true;
    }
}
