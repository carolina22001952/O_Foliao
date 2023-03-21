using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarslUI : MonoBehaviour
{
    [SerializeField]
    private GameObject BarGameObject;

    public void OpenBarsUI()
    {
        BarGameObject.SetActive(true);
    }

    public void CloseBarsUI()
    {
        BarGameObject.SetActive(false);
    }

}
