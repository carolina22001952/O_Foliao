using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelUi : MonoBehaviour
{
    [SerializeField]
    private GameObject BusGameObject;

    [SerializeField]
    private GameObject TunelGameObject;


    public void OpenBusUI()
    {
        BusGameObject.SetActive(true);
    }

    public void CloseBusUI()
    {
        BusGameObject.SetActive(false);
    }

    public void OpenTunelUI()
    {
        BusGameObject.SetActive(true);
    }

    public void CloseTunelUI()
    {
        BusGameObject.SetActive(false);
    }

}
