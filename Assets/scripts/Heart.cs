using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public  Sprite BroKenSprite;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        sr.sprite = BroKenSprite;
    }
}
