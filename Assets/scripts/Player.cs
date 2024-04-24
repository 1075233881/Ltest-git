using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //����
    //trank �ƶ��ٶ�
    public float moveSpeed = 3;
    private float timeVal;
    private float defendTimeVal=3;
    private bool isDefended=true;
    //�ӵ���ֽ����
    public Vector3 bullectEulerAngles;

    private SpriteRenderer sr;

    //�ӵ���ֽ
    public Sprite[] tankSprite;
    //�ӵ���ֽ
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;

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
        //�޵��ж�
        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
                defendEffectPrefab.SetActive(false);
            }
        }
        //����cd
        if (timeVal >= 0.4f)
        {
             Attack();
        }
        else
        {
            timeVal +=Time.deltaTime;
        }
        

    }
    private void FixedUpdate()
    {
        Move();
}
    //̹�˹���

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullectPrefab,transform.position,
                 Quaternion.Euler(transform.eulerAngles+bullectEulerAngles));
            timeVal = 0;
        }
    }

    //̹���ƶ�
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed *
         Time.deltaTime, Space.World);

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0) { 
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
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
        if (isDefended)
        {
            return ;
        }
        Instantiate(explosionPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
