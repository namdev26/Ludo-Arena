using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public List<Team> teams = new List<Team>();
    public int currentTeamIndex = 0;
    private PlayerPiece selectedPiece = null;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }


    private void Start()
    {
        if (DiceRoller.Instance != null)
        {
            DiceRoller.Instance.OnDiceRolled += HandleDiceResult;
        }
        else
        {
            Debug.LogError("DiceRoller not initialized before TurnManager Start");
        }
    }

    public void HandleDiceResult (int result)
    {
        StartCoroutine(SelectPieceAndMove(result));
    }

    public void NextTurn()
    {
        currentTeamIndex = (currentTeamIndex + 1) % teams.Count;
    }

    public void RepeatTurn()
    {
        
    }

    private IEnumerator SelectPieceAndMove(int diceResult)
    {
        Team currentTeam = teams[currentTeamIndex];
        List<PlayerPiece> selectablePieces = new();

        foreach (var piece in currentTeam.teamMembers)
        {
            if (!piece.IsOut && diceResult == 6)
            {
                selectablePieces.Add(piece);
                piece.SetSelectable(true);
            }
            else if (piece.IsOut && piece.currentNode != null)
            {
                selectablePieces.Add(piece);
                piece.SetSelectable(true);
            }
        }

        if (selectablePieces.Count == 0)
        {
            NextTurn();
            yield break;
        }

        selectedPiece = null;

        while (selectedPiece == null)
            yield return null;

        foreach (var piece in selectablePieces)
            piece.SetSelectable(false);

        var handler = new DiceResultHandler(selectedPiece);
        handler.HandleResult(diceResult);
    }


    public bool IsWaitingForSelection(PlayerPiece piece)
    {
        return teams[currentTeamIndex].teamMembers.Contains(piece) && selectedPiece == null;
    }

    public void SelectPiece(PlayerPiece piece)
    {
        selectedPiece = piece;
    }

}
