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

    private GameObject[] karelerDizisi = new GameObject[25];

    void Start()
    {
        kareleriOlustur();
        
    }

    
    public void kareleriOlustur()
    {
        for(int i=0; i<25; i++)
        {
            GameObject kare = Instantiate(karePrefab, karelerPanali);
            karelerDizisi[i] = kare;
        }

        BolumDegerleriniTexteYazdir();

        StartCoroutine(DoFadeRoutine());
        
    }

    IEnumerator DoFadeRoutine()
    {
        foreach(var kare in karelerDizisi)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);

            yield return new WaitForSeconds(0.07f);

           
        }
    }

     void BolumDegerleriniTexteYazdir()
    {
        foreach(var kare in karelerDizisi)
        {
            int rastgeleDeger = Random.Range(1,13);
           
            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();
        }
    }
}
