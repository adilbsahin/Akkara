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

    //Rigidbody'e eri�im i�in 
    private Rigidbody2D rb2d;

    //animat�re eri�im i�in
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

    //Update fonksiyonundan daha stabil �al���r bilgisayarlar aras� fark olmamas� i�in 
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

    //z�plama fonksiyonu
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

    //sa�a veya sola hareket ederken karakterin de y�n de�i�tirmesi sa�lan�yor
    private void YonDegistir()
    {
        Vector3 suankiyon = gameObject.transform.localScale;
        suankiyon.x *= -1;
        gameObject.transform.localScale = suankiyon;
        yonudogrumu = !yonudogrumu;
    }

    //s�n�rs�z z�plamay� engellemek i�in  yerde olup olmad��� kontrol ediliyor
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag =="Platform")
        {
            yerdemi = true;
        }
    }

}
