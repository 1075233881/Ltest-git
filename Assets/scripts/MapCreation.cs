using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    public GameObject[] item;

    private List<Vector3> itemPositionList = new List<Vector3>();
    private void Awake()
    {
        //home
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //homewall
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);

        }
        //创建边界
        for (int i = -11; i < 12; i++) {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -9; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
    }
    private void CreateItem(GameObject createGameObject,
        Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }
    //随机产生
    private Vector3 CreateRandomPosition()
    {
        //x=-10,10,y=-8,8
        while (true)
        {
            Vector3 createPosistion = new Vector3(Random.Range(-9, 10)
                , Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosistion)) { 
                return createPosistion;
            }
        }
    }
    //判断位置列表
    private bool HasThePosition(Vector3 createPos) {
        for (int i = 0; i< itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i]) { 
             return true;
            }
        }
        return false;
    }
}
