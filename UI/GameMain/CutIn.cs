using UnityEngine;

public class CutIn : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject cutIn;

    private Animator cutInAnim;

    private Animator charaAnim;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        cutInAnim = gameObject.GetComponent<Animator>();
        cutIn = Instantiate((GameObject)Resources.Load("Prefabs/Character/" + gameManager.MainCharacterName), transform.position, Quaternion.identity);
        cutIn.transform.parent = transform;

        if ((charaAnim = cutIn.GetComponent<Animator>()) != null)
        {
            charaAnim.enabled = true;
            charaAnim.SetBool("Pose", true);
        }
    }

    void OnEnable()
    {
        if (charaAnim != null)
            charaAnim.SetBool("Pose", true);
    }

    void Update()
    {
        PauseAnim();

        if ((charaAnim = cutIn.GetComponent<Animator>()) == null)
            return;

        if (charaAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            charaAnim.SetBool("Pose", false);
    }

    private void PauseAnim()
    {
        if (gameManager.IsPause)
        {
            cutInAnim.enabled = false;

            if (charaAnim != null)
                charaAnim.enabled = false;
        }
        else
        {
            if (!cutInAnim.enabled)
            {
                cutInAnim.enabled = true;

                if (charaAnim != null)
                    charaAnim.enabled = true;
            }
        }


    }
}
