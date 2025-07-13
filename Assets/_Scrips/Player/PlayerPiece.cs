using UnityEngine;

public class PlayerPiece : MonoBehaviour, IMoveable
{
    [Header("Piece Settings")]
    public PlayerColor playerColor;
    public Node currentNode;
    public bool IsOut { get; private set; } = false;

    [Header("Controllers")]
    public MovementController movementController;
    public AnimatorController animationController;

    public GameObject selectionEffect;
    public bool isMoving => movementController.IsMoving;

    private void Awake()
    {
        movementController = new MovementController(this);
        animationController = new AnimatorController(GetComponent<Animator>());
    }

    public void MoveStep(int steps)
    {
        if (isMoving) return;

        if (!IsOut)
        {
            if (steps == 6 && currentNode.nextNode != null)
            {
                IsOut = true;
                movementController.MoveSteps(1, () =>
                {
                    TurnManager.Instance.RepeatTurn();
                });
            }
            else
            {
                TurnManager.Instance.NextTurn();
            }
            return;
        }

        movementController.MoveSteps(steps, () =>
        {
            TurnManager.Instance.NextTurn();
        });
    }

    public void SetSelectable(bool isOn)
    {
        if (selectionEffect != null)
        {
            selectionEffect.SetActive(isOn);
        }
    }

    private void OnMouseDown()
    {
        if (TurnManager.Instance.IsWaitingForSelection(this))
        {
            TurnManager.Instance.SelectPiece(this);
        }
    }

    public bool CanBeSelectedWithDice(int diceValue)
    {
        if (IsOut) return true;
        if (!IsOut && diceValue == 6) return true;
        return false;
    }
}
