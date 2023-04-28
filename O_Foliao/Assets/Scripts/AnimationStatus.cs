using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStatus : MonoBehaviour
{
    //[SerializeField] private Animator animator;

    [SerializeField] private GameObject alcoholSprite;
    [SerializeField] private GameObject funSprite;
    [SerializeField] private GameObject energySprite;

    [SerializeField] private int scaleDuration;

    [SerializeField] private Vector3 scaleUp, originalScale;

    public void ChangeAlcoholSize()
    {   
        alcoholSprite.transform.localScale = scaleUp;
        StartCoroutine(Wait());
        alcoholSprite.transform.localScale = originalScale;
    }

    public void ChangeFunSize()
    {   
        funSprite.transform.localScale = scaleUp;
        StartCoroutine(Wait());
        funSprite.transform.localScale = originalScale;
    }

    public void ChangeEnergySize()
    {   
        energySprite.transform.localScale = scaleUp;
        StartCoroutine(Wait());
        energySprite.transform.localScale = originalScale;
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(scaleDuration);
    }
    
}
