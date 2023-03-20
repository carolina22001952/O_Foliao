using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhone : MonoBehaviour
{
    [SerializeField] Animator animator;

    private bool isMouseOver = false;

    void Play()
    {
        animator = GetComponent<Animator>();
    }
}
