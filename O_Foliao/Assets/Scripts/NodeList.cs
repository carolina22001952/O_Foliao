using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> nodeList;

    public List<GameObject> GetNodeList()
    {
        return nodeList;
    }
}
    