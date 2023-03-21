using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchUI : MonoBehaviour
{
    [SerializeField]
    private GameObject BenchGameObject;

    public void OpenBenchUI()
    {
        BenchGameObject.SetActive(true);
    }

    public void CloseBenchUI()
    {
        BenchGameObject.SetActive(false);
    }


}
