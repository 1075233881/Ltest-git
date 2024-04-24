using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   //����
    //trank �ƶ��ٶ�
    public float moveSpeed = 3;
    private float v;
    private float h;
    //�ӵ���ֽ����
    public Vector3 bullectEulerAngles;

    private SpriteRenderer sr;

    //��ʱ��
    private float timeVal;
    private float timeValChangeDirection;
    //�ӵ���ֽ
    public Sprite[] tankSprite;
    //�ӵ���ֽ
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        
        //����cd
        if (timeVal >= 3f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }


    }
    private void FixedUpdate()
    {
        Move();
    }
    //̹�˹���

    private void Attack()
    {

            Instantiate(bullectPrefab, transform.position,
                 Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeVal = 0;
        
    }
    
    //̹���ƶ�
    private void Move()
    {
        if (timeValChangeDirection >=4)
        {
            int num = Random.Range(0,8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0) {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num < 2) 
            {
                v = 0;
                h = 1;
            }
            else if (num > 2&&num<=4)
            {
                v = 0;
                h = -1;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.deltaTime;
        }
        
        // h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed *
         Time.deltaTime, Space.World);

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }
         //v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed *
         Time.deltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);

        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);

        }
    }
    //̹������
    private void Die()
    {
 
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}