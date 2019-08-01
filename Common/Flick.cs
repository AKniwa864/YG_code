using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    [SerializeField]
    private RectTransform select;

    [SerializeField]
    private UI.TitlePage titlePage;

    [SerializeField]
    private UI.TsumuSelect tsumuSelect;

    private Vector2 startPos;
    private Vector2 endPos;

    private Vector2 initPos;

    private Vector3 posAmount = new Vector3(Constants.SELECT_FLICK_AMOUNT, 0.0f, 0.0f);

    private bool move;

    void Start()
    {
        initPos = select.localPosition;
    }

    void Update()
    {
        if(titlePage.CurrentPage == Constants.TitlePageType.TsumuSelect)
            FlickChecker();
    }

    void FlickChecker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = endPos.x - startPos.x;
        float directionY = endPos.y - startPos.y;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
                StartMove(true);
            else if (-30 > directionX)
                StartMove(false);
        }
        else
        {
            startPos = initPos;
            endPos = initPos;
        }
    }

    public void StartMove(bool right)
    {
        if (move)
            return;

        StartCoroutine(Move(right));
    }

    private IEnumerator Move(bool right)
    {
        move = true;
        while (Mathf.Abs(select.localPosition.x) < 360)
        {
            if (right)
                select.localPosition += posAmount;
            else
                select.localPosition -= posAmount;

            yield return null;
        }

        select.localPosition = initPos;
        startPos = initPos;
        endPos = initPos;

        if (right)
            tsumuSelect.CurrentTsumu--;
        else
            tsumuSelect.CurrentTsumu++;

        move = false;
    }
}
