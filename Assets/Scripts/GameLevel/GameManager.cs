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
    private Sprite[] kareSprites;

    [SerializeField]
    private GameObject soruGameObject;

    
    List<int> UcgenDegerleriListesi = new List<int>();

    
    int butonDegeri;
    bool butonaBasilsinmi;

    int kalanHak;

    string sorununZorlukDerecesi;

    KalanHaklarManager KalanHaklarManager;

    PuanManager puanManager;

    GameObject gecerliKare;

    private void Awake()
    {
        kalanHak = 3;

        KalanHaklarManager = Object.FindObjectOfType<KalanHaklarManager>();
        puanManager = Object.FindObjectOfType<PuanManager>();

        KalanHaklarManager.KalanHaklariKontrolEt(kalanHak);
    }

    void Start()
    {
        butonaBasilsinmi = false;

        soruPaneli.GetComponent<RectTransform>().localScale = Vector3.zero;

        kareleriOlustur();
       

    }

    
    public void kareleriOlustur()
    {
        for(int i=0; i<25; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPanali);
            kare.transform.GetChild(1).GetComponent<Image>().sprite = kareSprites[Random.Range(0, kareSprites.Length)];
            kare.transform.GetComponent<Button>().onClick.AddListener(() => ButonaBasildi());
            karelerDizisi[i] = kare;
        }

        UcgenDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());

        Invoke("SoruPaneliniAc",2f);


    }

     void ButonaBasildi()
    {
        if (butonaBasilsinmi)
        {
            butonDegeri = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);

            gecerliKare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            SorununZorlukDerecesi();
            SonucuKontrolEt();
            


        }
    }

    void SonucuKontrolEt()
    {
        if (13 <= butonDegeri)
        {
            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;

            puanManager.PuaniArtir(sorununZorlukDerecesi);

            if (butonDegeri > 13)
            {
                SoruPaneliniAc();
            }
            else
            {
                OyunBitti();
            }

        }
        else 
        {
            gecerliKare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            gecerliKare.transform.GetChild(0).GetComponent<Text>().text = "";
            gecerliKare.transform.GetComponent<Button>().interactable = false;
            kalanHak--;
            KalanHaklarManager.KalanHaklariKontrolEt(kalanHak);
        }
        

        if (kalanHak <= 0)
        {
            OyunBitti();
        }
    }

    void SorununZorlukDerecesi()
    {
        if (butonDegeri > 13 && butonDegeri <= 25)
        {
            sorununZorlukDerecesi = "kolay";
        }else if(butonDegeri > 25 && butonDegeri <= 35)
        {
            sorununZorlukDerecesi = "orta";
        }
        else
        {
            sorununZorlukDerecesi = "zor";
        }

    }

    void OyunBitti()
    {
        Debug.Log("oyun bitti");
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
            int rastgeleDeger = Random.Range(1,40);

            UcgenDegerleriListesi.Add(rastgeleDeger);

           
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();
        }
       
    }

    void SoruPaneliniAc()
    {
        butonaBasilsinmi = true;
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    


}
