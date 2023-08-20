using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] 
    GameObject logo, lesson1btn, lesson2btn, lesson3btn, lesson4btn, lesson5btn;

    void Start()
    {
     LeanTween.scale(logo, new Vector3(1.5f,1.5f,1.5f),2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
     LeanTween.scale(logo, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }
}
