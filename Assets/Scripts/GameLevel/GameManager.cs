using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject karePrefab;

    [SerializeField]
    private Transform karelerPanali;

    [SerializeField]
    private Image soruImage;

    private GameObject[] karelerDizisi = new GameObject[25];

    [SerializeField]
    private Transform soruPaneli;

    [SerializeField]
    private GameObject soruGameObject;

    
    List<int> UcgenDegerleriListesi = new List<int>();

    int butonDegeri;

    void Start()
    {
        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kareleriOlustur();
        
    }

    
    public void kareleriOlustur()
    {
        for(int i=0; i<25; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPanali);
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());
            karelerDizisi[i] = kare;
        }

        UcgenDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());

        Invoke("SoruPaneliniAc",2f);


    }

     void ButonaBasildi()
    {
        butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
        Debug.Log(butonDegeri);
    }


    IEnumerator DoFadeRoutine()
    {
        foreach(var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

            yield return new WaitForSeconds(0.07f);

           
        }
    }

     void UcgenDegerleriniTexteYazdir()
    {
        foreach(var kare in karelerDizisi)
        {
            int rastgeleDeger = Random.Range(12,35);

            UcgenDegerleriListesi.Add(rastgeleDeger);

           
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();
        }
       
    }

    void SoruPaneliniAc()
    {
        
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    

    
}
