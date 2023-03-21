using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public enum Type { Stages, Bars, Hotels };

    [SerializeField]
    private Type type;
    [SerializeField]
    private Sprite normal;
    [SerializeField]
    private Sprite highLight;
    public Node node;
    [SerializeField]
    private List<ILocal> local;

    [System.Serializable]
    public struct TargetNode
    {
        public Node target;
        public List<Transform> waypoints;
    }

    [SerializeField]
    List<TargetNode> options;

    public List<TargetNode> GetOptions()
    {
        return options;
    }

    public void HighLight()
    {
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().sprite = highLight;
    }

    public void BacktoNormal()
    {
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().sprite = normal;
    }

    public Node GetNode(Player player)
    {
        return player.Position().GetComponent<Node>();
    }


    public Type NodeType(Player player)
    {
        node = GetNode(player);
        return node.type;
    }

    public void UpdateMaterials()
    {
        foreach(TargetNode targetlist in options)
        {
            HighLight();
        }
    }
}

