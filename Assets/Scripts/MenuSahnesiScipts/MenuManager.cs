using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject StartButton, ExitButton;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FadeOut();
        
    }
    public void FadeOut()
    {
        StartButton.GetComponent<CanvasGroup>().DOFade(1f,0.8f);  //solgun açılıri, belirginleşme efekti verilir.
        ExitButton.GetComponent<CanvasGroup>().DOFade(1f, 0.8f).SetDelay(0.5f);
    }
    public void ClickStart()
    {
        SceneManager.LoadScene("GameSahnesi");
    }
    public void ClickExit()
    {
        Application.Quit();
    }
}
