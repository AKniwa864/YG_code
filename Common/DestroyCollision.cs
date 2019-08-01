using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    private List<GameObject> destroyTsumuList = new List<GameObject>();
    public List<GameObject> DestroyTsumuList
    {
        set { destroyTsumuList = value; }
        get { return destroyTsumuList; }
    }

    void OnEnable()
    {
        destroyTsumuList = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tsumu")
            destroyTsumuList.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        destroyTsumuList.Remove(col.gameObject);
    }
}