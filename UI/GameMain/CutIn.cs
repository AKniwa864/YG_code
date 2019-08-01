using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutIn : MonoBehaviour
{
    [SerializeField]
    private Image character;

    [SerializeField]
    private Animator cutIn;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        character.sprite = gameManager.MainCharacterSprite;
    }

    void Update()
    {
        if (cutIn.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }
}
