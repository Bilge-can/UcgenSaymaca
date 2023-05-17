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

    [SerializeField]
    public Image soru; // Unity sahnesinde yerleştirdiğiniz Image bileşeni

    [SerializeField]
    public Sprite[] imageArray; // Resimleri tutacak dizi
   
    List<int> UcgenDegerleriListesi = new List<int>();

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
            karelerDizisi[i] = kare;
        }

        UcgenDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());

        Invoke("SoruPaneliniAc",2f);

        

        
        //SoruDizi();


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
            int rastgeleDeger = Random.Range(1,13);

            UcgenDegerleriListesi.Add(rastgeleDeger);

           
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();
        }
       
    }

    void SoruPaneliniAc()
    {
        SoruyuSor();
        soruPaneli.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutBack);
    }

    /*

     public void SoruDizi()
    {
        Debug.Log("------------");
        // Resim dizisini oluşturun ve resimleri atayın
        imageArray = new Sprite[]
        {
            Resources.Load<Sprite>("1.png"), // Resim1, Resources klasöründe bulunan resim dosyasının adı
            Resources.Load<Sprite>("2.png"),
            Resources.Load<Sprite>("3.png"),
            Resources.Load<Sprite>("4.png"),
            Resources.Load<Sprite>("5.png"),
            Resources.Load<Sprite>("6.png"),
            // Eklemek istediğiniz diğer resimleri buraya ekleyebilirsiniz
        };

        // Rastgele resim gösterme işlemini başlatın
        Debug.Log("------------1");
        // Rastgele bir resim seçin
        int randomIndex = Random.Range(0, imageArray.Length);
        Sprite randomImage = imageArray[randomIndex];

        // Image bileşenine seçilen resmi atayın
        soru.GetComponent<Image>().sprite = Resources.Load<Sprite>("6.png");
        Debug.Log("burada");
    }
    */

    void SoruyuSor()
    {
        imageArray = new Sprite[]
        {
            Resources.Load<Sprite>("1.png"), // Resim1, Resources klasöründe bulunan resim dosyasının adı
            Resources.Load<Sprite>("2.png"),
            Resources.Load<Sprite>("3.png"),
            Resources.Load<Sprite>("4.png"),
            Resources.Load<Sprite>("5.png"),
            Resources.Load<Sprite>("6.png"),
            // Eklemek istediğiniz diğer resimleri buraya ekleyebilirsiniz
        };

        // Rastgele bir resim seçin
        int randomIndex = Random.Range(0, imageArray.Length);
        Sprite randomImage = imageArray[randomIndex];

        // Image bileşenine seçilen resmi atayın
        soru.GetComponent<Image>().sprite = Resources.Load<Sprite>("6.png");
        Debug.Log("burada");
    }
}
