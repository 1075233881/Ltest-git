using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullect : MonoBehaviour
{
    public float moveSpeed = 10;
    public bool isPlayBullect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BullctDestroy();
    }
    private void Move()
    {
        transform.Translate(transform.up *
            moveSpeed * Time.deltaTime, Space.World);
    }
    private void BullctDestroy()
    {
        Destroy(gameObject,5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            switch (collision.tag)
        {
            case"Tank":
                if (!isPlayBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Enemy":
                if (isPlayBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Heart":
                Destroy(gameObject);
                collision.SendMessage("Die");
                break;
            case"Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case"Barrier":
                Destroy(gameObject);
                break;
        }
    }
}
