using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{
    [SerializeField]
    private List<Node> nodeList;

    public List<Node> GetNodeList()
    {
        return nodeList;
    }
}
    