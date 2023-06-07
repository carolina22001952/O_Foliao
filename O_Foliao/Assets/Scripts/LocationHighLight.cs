using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationHighLight : MonoBehaviour
{
    private GameObject location;
    [SerializeField]
    private Node node;
    private void OnMouseOver()
    {
        node.QuestHighLight(location);
    }

    private void OnMouseExit()
    {
        node.QuestToNormal(location);
    }

    public void UpdateLocation(GameObject newLocation)
    {
        this.location = newLocation;
    }

}
