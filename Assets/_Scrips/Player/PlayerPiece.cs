using System;
using System.Collections;
using UnityEngine;

public class PlayerPiece : MonoBehaviour
{
    public Node currentNode;
    public float speed = 5f;
    public bool isMoving = false;
    public Animator animator;

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) MoveStep(1);
            if (Input.GetKeyDown(KeyCode.Alpha2)) MoveStep(2);
            if (Input.GetKeyDown(KeyCode.Alpha3)) MoveStep(3);
            if (Input.GetKeyDown(KeyCode.Alpha4)) MoveStep(4);
            if (Input.GetKeyDown(KeyCode.Alpha5)) MoveStep(5);
        }
    }

    public void MoveStep(int steps) 
    {
        StartCoroutine(MoveCoroutine(steps));
    }

    IEnumerator MoveCoroutine(int steps)
    {
        isMoving = true;
        animator.Play("WalkForward");

        for (int i = 0; i < steps; i++)
        {
            if (currentNode.nextNode == null)
                break;

            Node nextNode = currentNode.nextNode;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = nextNode.transform.position + Vector3.up * 0.5f;

            float distance = Vector3.Distance(startPosition, endPosition);
            float duration = distance / speed;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition;
            currentNode = nextNode;
        }
        animator.Play("Idle01");
        isMoving = false;
    }

}
