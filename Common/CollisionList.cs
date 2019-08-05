using System.Collections.Generic;
using UnityEngine;

public class CollisionList : MonoBehaviour
{
    private List<GameObject> tsumuList = new List<GameObject>();
    public List<GameObject> TsumuList
    {
        set { tsumuList = value; }
        get { return tsumuList; }
    }

    void OnEnable()
    {
        tsumuList = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tsumu")
            tsumuList.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        tsumuList.Remove(col.gameObject);
    }
}