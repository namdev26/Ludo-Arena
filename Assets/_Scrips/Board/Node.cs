using UnityEngine;

public enum NodeType
{
    Start,
    Normal,
    Home,
    Safe,
    Branch,
    Goal
}

public enum PlayerColor
{
    None,
    Red,
    Blue,
    Yellow,
    Green
}

public class Node : MonoBehaviour
{
    [Header("Node Infor")]
    public NodeType nodeType;
    public PlayerColor ownerColor = PlayerColor.None;

    [Header("Node Link")]
    public Node nextNode;
    public Node branchNode;

    [Header("Node Display Editor")]
    public Color gizmoColor = Color.white;
    public float gizmoSize = 0.2f;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, gizmoSize);

        if (nextNode != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, nextNode.transform.position);
        }

        if (nodeType == NodeType.Branch && branchNode != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, branchNode.transform.position);
        }
    }
}
