using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    [SerializeField] private float harekethizi;
    [SerializeField] private float ziplamagucu;

    private float yatayhareket;
    private bool yerdemi = false;
    private bool yonudogrumu = true;

    //Rigidbody'e eriþim için 
    private Rigidbody2D rb2d;

    //animatöre eriþim için
    private Animator karakterAnimator;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        karakterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Zipla();

        if (yatayhareket > 0 && !yonudogrumu)
            YonDegistir();
        else if (yatayhareket < 0 && yonudogrumu)
            YonDegistir();
    }

    //Update fonksiyonundan daha stabil çalýþýr bilgisayarlar arasý fark olmamasý için 
    private void FixedUpdate()
    {
        Hareket();
    }

    //hareket fonksiyonu
    private void Hareket()
    {
        yatayhareket = Input.GetAxis("Horizontal");
        transform.position += new Vector3(yatayhareket * harekethizi * Time.deltaTime, 0, 0);
        karakterAnimator.SetFloat("Hizi", Mathf.Abs(yatayhareket));
    }

    //zýplama fonksiyonu
    private void Zipla()
    {
        if(Input.GetKeyDown(KeyCode.Space) && yerdemi)
        {
            yerdemi = false;
            rb2d.velocity = Vector2.up * ziplamagucu;
        }
        if(!yerdemi)
        {
            karakterAnimator.SetBool("Zipliyormu", true);
        }
        else if(yerdemi)
        {
            karakterAnimator.SetBool("Zipliyormu", false);
        }
    }

    //saða veya sola hareket ederken karakterin de yön deðiþtirmesi saðlanýyor
    private void YonDegistir()
    {
        Vector3 suankiyon = gameObject.transform.localScale;
        suankiyon.x *= -1;
        gameObject.transform.localScale = suankiyon;
        yonudogrumu = !yonudogrumu;
    }

    //sýnýrsýz zýplamayý engellemek için  yerde olup olmadýðý kontrol ediliyor
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Platform")
        {
            yerdemi = true;
        }
    }

}
