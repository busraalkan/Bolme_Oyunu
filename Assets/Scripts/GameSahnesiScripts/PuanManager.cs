using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuanManager : MonoBehaviour
{
    [SerializeField]
    private Text PuanText;
    int ToplamPuan;
    int EklenenPuan;
    void Start()
    {
        PuanText.text = ToplamPuan.ToString();
    }
    public void PuanHesapla(string ZorlukSeviyesi)
    {
        switch (ZorlukSeviyesi)
        {
            case "Kolay":
                EklenenPuan = 5;
                break;
            case "Orta":
                EklenenPuan = 10;
                break;
            case "Zor":
                EklenenPuan = 15;
                break;
        }
        ToplamPuan = ToplamPuan + EklenenPuan;
        PuanText.text = ToplamPuan.ToString();
    }
}