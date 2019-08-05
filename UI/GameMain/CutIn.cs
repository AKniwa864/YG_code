using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutIn : MonoBehaviour
{
    [SerializeField]
    private Image character;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        character.sprite = gameManager.MainCharacterSprite;
    }
}
