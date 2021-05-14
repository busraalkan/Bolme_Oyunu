using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject KarePrefab;
    [SerializeField]
    private Transform KarelerPaneli;
    private GameObject[] KarelerDizisi = new GameObject[25];
    [SerializeField]
    private Transform SoruPaneli;
    [SerializeField]
    private Sprite[] Sprites = new Sprite[5];
    [SerializeField]
    private GameObject SonucPaneli;
    [SerializeField]
    private GameObject CanlarPaneli;
    [SerializeField]
    AudioSource Ses;
    public AudioClip DogruButonSesi;
    public AudioClip YanlisButonSesi;
    List<int> BolumDegerleriList = new List<int>();
    int bolen, bolunen, indeks;
    int ButonDegeri;
    bool ButonAcikMi;
    int Cevap;
    KalanCanlarManager KalanCanObject;
    PuanManager PuanManagerObj;
    int Cansayisi;
    string ZorlukDerecesi;
    GameObject GeciciButonDeger;


    private void Awake()
    {
        Ses = GetComponent<AudioSource>();
        SonucPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        Cansayisi = 3;
        KalanCanObject = Object.FindObjectOfType<KalanCanlarManager>();
        KalanCanObject.KalanCanSayisi(Cansayisi);
        PuanManagerObj = Object.FindObjectOfType<PuanManager>();
    }
    void Start()
    {
        ButonAcikMi = false;
        AcilistaSoruPaneliGizle();
        Invoke("SoruPaneliniGetir", 5f);
        KareleriUret();
        StartCoroutine(KareleriDoFadeYap());
        KutucuklaraDegerAta();
        SoruyuSor();
        SorununZorlukDerecesiniBul();
    }
    public void KareleriUret()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject TempKare = Instantiate(KarePrefab, KarelerPaneli);
            TempKare.GetComponent<Button>().onClick.AddListener(() => KareButonunaBas());
            TempKare.transform.GetChild(1).GetComponent<Image>().sprite = Sprites[Random.Range(0, Sprites.Length)];
            KarelerDizisi[i] = TempKare;
        }
    }

    IEnumerator KareleriDoFadeYap()
    {
        foreach (var kare in KarelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
    }
    void KutucuklaraDegerAta()
    {
        foreach (var deger in KarelerDizisi)
        {
            int RastgeleDeger = UnityEngine.Random.Range(0, 16);
            BolumDegerleriList.Add(RastgeleDeger);
            deger.transform.GetChild(0).GetComponent<Text>().text = RastgeleDeger.ToString();
        }
    }
    void AcilistaSoruPaneliGizle()
    {
        SoruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
    void SoruPaneliniGetir()
    {
        SoruPaneli.GetComponent<RectTransform>().DOScale(1.2f, 0.5f);
        ButonAcikMi = true;
    }
    void SoruyuSor()
    {
        bolen = Random.Range(2, 11);
        indeks = Random.Range(0, BolumDegerleriList.Count);
        Cevap = BolumDegerleriList[indeks];
        bolunen = bolen * Cevap;
        SoruPaneli.transform.GetChild(0).GetComponent<Text>().text = bolunen.ToString() + " : " + bolen.ToString();
    }
    void KareButonunaBas()
    {
        if (ButonAcikMi == true)
        {
            ButonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            GeciciButonDeger = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            CevapDogruMu();
        }
    }
    void CevapDogruMu()
    {
        if (ButonDegeri == Cevap)
        {
            Ses.PlayOneShot(DogruButonSesi);
            PuanManagerObj.PuanHesapla(ZorlukDerecesi);
            BolumDegerleriList.RemoveAt(indeks);
            GeciciButonDeger.transform.GetChild(1).GetComponent<Image>().enabled = true;
            GeciciButonDeger.transform.GetChild(0).GetComponent<Text>().text = "";
            GeciciButonDeger.GetComponent<Button>().interactable = false;
            if (BolumDegerleriList.Count > 0)
            {
                SoruyuSor();
            }
            else
            {
                OyunBitti();
            }

        }
        else
        {
            Ses.PlayOneShot(YanlisButonSesi);
            Cansayisi--;
            KalanCanObject.KalanCanSayisi(Cansayisi);
        }
        if(Cansayisi<=0)
        {
            OyunBitti();
        }
    }
    void SorununZorlukDerecesiniBul()
    {
        if (bolunen <= 40)
        {
            ZorlukDerecesi = "Kolay";
        }
        else if (bolunen > 40 && bolunen < 80)
        {
            ZorlukDerecesi = "Orta";
        }
        else
        {
            ZorlukDerecesi = "Zor";
        }
    }
    void OyunBitti()
    {
        CanlarPaneli.SetActive(false);
        KarelerPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        SoruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        SonucPaneli.GetComponent<RectTransform>().DOScale(1.2f, 0.5f);
    }
}
