using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYumurtlama : MonoBehaviour
{
    [SerializeField]
    private GameObject dusmanPrefab;
    

    [SerializeField]
    private float dusmanAralik = 3.5f;

    [SerializeField]
    private GameObject player;

    void Start()
    {
        StartCoroutine(Yumurtla(dusmanAralik, dusmanPrefab));
        
    }
    //Düþman oluþturma
    private IEnumerator Yumurtla(float aralik, GameObject dusman)
    {
        if (player != null)
        {
            yield return new WaitForSeconds(dusmanAralik);
            GameObject newDusman = Instantiate(dusman, new Vector3(Random.Range(-9f, -17f), Random.Range(-3f, -4f), 0), Quaternion.identity);
            StartCoroutine(Yumurtla(aralik, dusman));
        }
    }
}
