using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYumurtlama2 : MonoBehaviour
{
    [SerializeField]
    private GameObject dusman2Prefab;
    [SerializeField]
    private float dusman2Aralik = 3f;
    [SerializeField]
    private GameObject player;
    void Start()
    {
        StartCoroutine(Yumurtla(dusman2Aralik, dusman2Prefab));
    }
    private IEnumerator Yumurtla(float aralik, GameObject dusman)
    {
        if (player != null)
        {
            yield return new WaitForSeconds(dusman2Aralik);
            GameObject newDusman = Instantiate(dusman, new Vector3(Random.Range(9f, 16f), Random.Range(-3f, -4f), 0), Quaternion.identity);
            StartCoroutine(Yumurtla(aralik, dusman));
        }
    }

}
