using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public int maxcan = 1;
    int suankiCan;


    [SerializeField] private float hiz = 5f;

    private GameObject player;

    public static Action OnPlayerDeath;
    
    //baþlangýçta caný 1 e eþitleyip bulunacak oyun objesinin tag ini player olarak ayarlýyor
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        suankiCan = maxcan;
    }

    void Update()
    {
        Takip();


    }

    //hasar alma durumunda 1 can eksiltip öl fonksiyonu devreye girmiþ oluyor
    public void AlinanHasar(int hasar)
    {
        suankiCan -= hasar;

        if (suankiCan <= 0) 
        {
            Ol();
        }
    }

    //düþmanýn ölme fonksiyonu
    void Ol()
    {
        Destroy(gameObject,0.35f);
    }

    //sürekli karakteri takip etmesini saðlýyor
    private void Takip()
    {
        if (player!= null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, hiz * Time.deltaTime);
        }
    }
    
    //karaktere temas ederse karakterin ölmesini saðlýyor
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player") 
        {
            Destroy(player);
            Time.timeScale = 0;
            OnPlayerDeath?.Invoke();
        }
    }


}
