using UnityEngine;

public class CutIn : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject cutIn;

    private Animator cutInAnim;

    private Animator poseAnim;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        cutInAnim = gameObject.GetComponent<Animator>();
        cutIn = Instantiate((GameObject)Resources.Load("Prefabs/Character/" + gameManager.MainCharacterName), transform.position, Quaternion.identity);
        cutIn.transform.parent = transform;

        if ((poseAnim = cutIn.GetComponent<Animator>()) != null)
            poseAnim.SetBool("Pose", true);
    }

    void OnEnable()
    {
        if (poseAnim != null)
            poseAnim.SetBool("Pose", true);
    }

    void Update()
    {
        PauseAnim();

        if ((poseAnim = cutIn.GetComponent<Animator>()) == null)
            return;

        if (poseAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            poseAnim.SetBool("Pose", false);
    }

    private void PauseAnim()
    {
        if (gameManager.IsPause)
        {
            cutInAnim.enabled = false;

            if (poseAnim != null)
                poseAnim.enabled = false;
        }
        else
        {
            if (!cutInAnim.enabled)
            {
                cutInAnim.enabled = true;

                if (poseAnim != null)
                    poseAnim.enabled = true;
            }
        }


    }
}
