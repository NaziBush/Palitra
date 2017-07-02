using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{

    Animator anim;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }
    void OnEnable()
    {
        EventManager.StartListening("BeginGameAnimation", Animate);
        EventManager.StartListening("ResetGameAnimation", Reset);
    }

    void OnDisable()
    {
        EventManager.StartListening("BeginGameAnimation", Animate);
        EventManager.StartListening("ResetGameAnimation", Reset);
    }

    void Animate()
    {
        anim.SetBool("animate", true);
    }

    void Reset()
    {
        anim.SetBool("animate", false);
    }
}
