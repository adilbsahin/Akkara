using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterSaldiri : MonoBehaviour
{
    public Animator animasyon;

    public Transform saldiriNoktasi;
    public float menzil = 0.5f;
    public LayerMask dusmanLayers;
    public int alinanHasar = 1;

    public float salSayisi = 2f;
    float siradakiSaldiri = 0.2f;

    //Update içerisindeki if durumu saldýrýlar arasýna süre koyuyor
    void Update()
    {
        if (Time.time >= siradakiSaldiri)
        {
            if (Input.GetMouseButton(0))
            {
                Saldir();
                siradakiSaldiri = Time.time + 1f / salSayisi;
            }
        }
    }

    //Saldýrý yapýyor ve düþman layer'ýna temas ederse hasar veriyor
    void Saldir()
    {
        animasyon.SetTrigger("Saldir");

        Collider2D[] hitDusman = Physics2D.OverlapCircleAll(saldiriNoktasi.position, menzil, dusmanLayers);
        
        foreach(Collider2D dusman in hitDusman)
        {
            dusman.GetComponent<Dusman>().AlinanHasar(alinanHasar);
        }
    }

    //Saldýrý alanýný editör içerisinde þekillendirmemizi saðlýyor
    private void OnDrawGizmosSelected()
    {
        if (saldiriNoktasi == null)
            return;

        Gizmos.DrawWireSphere(saldiriNoktasi.position, menzil);
    }
}
