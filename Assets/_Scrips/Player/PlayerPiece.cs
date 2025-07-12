using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public Node currentNode;
    public MovementController movementController;
    public AnimatorController animationController;
    public bool isMoving => movementController.IsMoving;

    private void Awake()
    {
        movementController = new MovementController(this);
        animationController = new AnimatorController(GetComponent<Animator>());
    }

    private void Update()
    {
        if (!isMoving)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                {
                    MoveStep(i);
                    break;
                }
            }
        }
    }

    public void MoveStep(int steps)
    {
        movementController.MoveSteps(steps);
    }
}
