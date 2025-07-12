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
    public MeshRenderer meshRenderer;

    void Start()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        //ApplyColor();
    }

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

    //void ApplyColor()
    //{
    //    switch (nodeType)
    //    {
    //        case NodeType.Start:
    //            meshRenderer.material.color = Color.blue;
    //            break;
    //        case NodeType.Safe:
    //            meshRenderer.material.color = Color.green;
    //            break;
    //        case NodeType.Home:
    //            meshRenderer.material.color = Color.yellow;
    //            break;
    //        case NodeType.Goal:
    //            meshRenderer.material.color = Color.red;
    //            break;
    //        case NodeType.Branch:
    //            meshRenderer.material.color = Color.cyan;
    //            break;
    //    }
    //}
}
