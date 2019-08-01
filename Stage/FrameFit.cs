using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameFit : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer frame; 

    void Start()
    {
        FitScreenWidth();
    }

    private void FitScreenWidth()
    {
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float width = frame.sprite.bounds.size.x - 1.5f;

        transform.localScale = new Vector3(worldScreenWidth / width, transform.localScale.y);
    }
}
