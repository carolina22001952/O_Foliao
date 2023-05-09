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

    private IEnumerator ScaleSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.transform.GetComponentInChildren<SpriteRenderer>();
        float scale = 0.012f;
        float maxScale = 0.02f;
        float step = 0.0001f;
        bool scalingUp = true;
        while (true)
        {
            if (scalingUp)
            {
                scale += step;
                if (scale > maxScale)
                {
                    scalingUp = false;
                    scale = maxScale;
                }
            }
            else
            {
                scale -= step;
                if (scale < 0.012f)
                {
                    scalingUp = true;
                    scale = 0.012f;
                }
            }
            spriteRenderer.transform.localScale = new Vector3(scale, scale, 1);
            yield return null;
        }
    }

    public void HighLight()
    {
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().sprite = highLight;
        StartCoroutine(ScaleSprite());
    }

    public void BacktoNormal()
    {
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().sprite = normal;
        StopAllCoroutines();
        gameObject.transform.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(0.012f, 0.014f, 1);
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

