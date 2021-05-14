using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalanCanlarManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] KalanCanlarDizisi = new GameObject[3];
    public void KalanCanSayisi(int CanSayisi)
    {
        switch (CanSayisi)
        {
            case 3:
                KalanCanlarDizisi[0].SetActive(true);
                KalanCanlarDizisi[1].SetActive(true); 
                KalanCanlarDizisi[2].SetActive(true);
                break;
            case 2:
                KalanCanlarDizisi[0].SetActive(true);
                KalanCanlarDizisi[1].SetActive(true);
                KalanCanlarDizisi[2].SetActive(false);
                break;
            case 1:
                KalanCanlarDizisi[0].SetActive(true);
                KalanCanlarDizisi[1].SetActive(false);
                KalanCanlarDizisi[2].SetActive(false);
                break;
            case 0:
                KalanCanlarDizisi[0].SetActive(false);
                KalanCanlarDizisi[1].SetActive(false);
                KalanCanlarDizisi[2].SetActive(false);
                break;
        }
    }
}
