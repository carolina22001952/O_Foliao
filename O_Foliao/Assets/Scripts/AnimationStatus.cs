using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStatus : MonoBehaviour
{
    //[SerializeField] private Animator animator;

    [SerializeField] private SpriteRenderer alcoholSprite;
    [SerializeField] private SpriteRenderer funSprite;
    [SerializeField] private SpriteRenderer energySprite;

    [SerializeField] private int scaleDuration;

    [SerializeField] private Vector3 scaleUp, originalScale;

    public void ChangeAlcoholSize()
    {   
        StartCoroutine(ChangeSizeCR(alcoholSprite.transform));
    }

    IEnumerator ChangeSizeCR(Transform target)
    {
        float s = 0.0f;
        while (s < 1.0f)
        {
            target.localScale = Vector3.Lerp(originalScale, scaleUp, s);
            s = s + Time.deltaTime;
            yield return null;
        }
        target.localScale = scaleUp;
        yield return new WaitForSeconds(scaleDuration);
        while (s > 0.0f)
        {
            target.localScale = Vector3.Lerp(originalScale, scaleUp, s);
            s = s - Time.deltaTime;
            yield return null;
        }
        target.localScale = originalScale;
    }

    public void ChangeFunSize()
    {   
        StartCoroutine(ChangeSizeCR(funSprite.transform));
    }

    public void ChangeEnergySize()
    {   
        StartCoroutine(ChangeSizeCR(energySprite.transform));
    }    
}
