using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    private Image img;
    private void Start()
    {
        img = GetComponent<Image>();
        Fade();
    }

    void Fade()
    {
        img.DOFade(0.5f, 1f).SetLoops(-1);
    }
}
