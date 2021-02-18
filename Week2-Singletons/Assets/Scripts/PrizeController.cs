using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour
{
    public GameObject prize;

    private GameObject objTemp;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= GameManager.instance.prizeCount; i++)
        {
            Vector3 posTemp = new Vector3(Random.Range(-8,8), 0, Random.Range(-3,6));
            Vector3 sizeTemp = gameObject.transform.localScale;
            sizeTemp.x += GameManager.instance.prizeSizeModifier;
            sizeTemp.y += GameManager.instance.prizeSizeModifier;
            
            objTemp = Instantiate(prize, posTemp, Quaternion.identity);
            objTemp.transform.localScale = sizeTemp;
        }
    }
}
