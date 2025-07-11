using UnityEngine;
using System.Collections;

public class MovementController
{
    private readonly PlayerPiece piece;
    private readonly float speed = 2f;
    private readonly float turnSpeedMultiplier = 8f;
    public bool IsMoving { get; private set; }

    public MovementController(PlayerPiece piece)
    {
        this.piece = piece;
    }

    public void MoveSteps(int steps)
    {
        piece.StartCoroutine(MoveCoroutine(steps));
    }

    private IEnumerator MoveCoroutine(int steps)
    {
        IsMoving = true;
        piece.animationController.PlayWalk();

        for (int i = 0; i < steps; i++)
        {
            if (piece.currentNode.nextNode == null) break;

            Node nextNode = piece.currentNode.nextNode;
            Vector3 start = piece.transform.position;
            Vector3 end = nextNode.transform.position + Vector3.up * 0.5f;
            Vector3 dir = (end - start).normalized;

            Quaternion startRot = piece.transform.rotation;
            Quaternion endRot = Quaternion.LookRotation(dir);
            float dist = Vector3.Distance(start, end);
            float duration = dist / speed;
            float t = 0f;

            while (t < duration)
            {
                float progress = t / duration;
                float turnProgress = Mathf.Clamp01(progress * turnSpeedMultiplier);

                piece.transform.position = Vector3.Lerp(start, end, progress);
                piece.transform.rotation = Quaternion.Slerp(startRot, endRot, turnProgress);

                t += Time.deltaTime;
                yield return null;
            }

            piece.transform.position = end;
            piece.currentNode = nextNode;
        }

        piece.animationController.PlayIdle();
        IsMoving = false;
    }
}
