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
    [SerializeField]
    private Sprite questHighLight;
    [SerializeField]
    private Sprite deactivatedNode;
    public Node node;
    [SerializeField]
    private List<ILocal> local;
    bool stop = false;

    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip audioClip;

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
        float scale = 0.01f;
        float maxScale = 0.013f;
        float step = 0.00005f;
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
                if (scale < 0.01f)
                {
                    scalingUp = true;
                    scale = 0.01f;
                }
            }
            spriteRenderer.transform.localScale = new Vector3(scale, scale, 1);
            yield return null;
        }
    }

    public void HighLight()
    {
        if (gameObject.transform.GetComponentInChildren<SpriteRenderer>(true).gameObject.activeSelf == true)
        {
            gameObject.transform.GetComponentInChildren<SpriteRenderer>(true).sprite = highLight;

            if (stop == false)
            {

                StartCoroutine(ScaleSprite());
                
            }
        }      
    }

    public void BacktoNormal()
    {
        gameObject.transform.GetComponentInChildren<SpriteRenderer>(true).sprite = normal;
        StopAllCoroutines();
        gameObject.transform.GetComponentInChildren<SpriteRenderer>(true).transform.localScale = new Vector3(0.01f, 0.01f, 1);
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

    public void QuestHighLight(GameObject location)
    {
        location.transform.GetComponentInChildren<SpriteRenderer>().sprite = questHighLight;
    }

    public void QuestToNormal(GameObject location)
    {
        location.transform.GetComponentInChildren<SpriteRenderer>().sprite = normal;
    }

    public void QuestToDeactivate(GameObject location)
    {

        location.transform.GetComponentInChildren<SpriteRenderer>().sprite = deactivatedNode;
    }

    public void StopAnimation(bool stop)
    {
        this.stop = stop;
    }

    public void NodeSound()
    {
        audioManager.ChooseMusic(audioClip);
    }
}

