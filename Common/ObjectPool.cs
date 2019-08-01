using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private List<GameObject> availableList = new List<GameObject>();

    public void PopObj(Vector2 pos)
    {
        GameObject tempObj;

        if (availableList == null || availableList.Count <= 0)
        {
            tempObj = Instantiate(obj, pos, Quaternion.identity);
            tempObj.transform.parent = transform;
        }
        else
        {
            availableList[0].transform.position = pos;
            availableList[0].SetActive(true);
            availableList.RemoveAt(0);
        }
    }

    public void PushObj(GameObject obj)
    {
        availableList.Add(obj);
    }
}
