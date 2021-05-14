using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaKontrol : MonoBehaviour
{
    public GameObject AlphaPaneli;
    void Start()
    {
        AlphaPaneli.GetComponent<CanvasGroup>().DOFade(0, 3f);
    }

}
