using UnityEngine;

public class Flick : MonoBehaviour
{
    private UI.TitlePage titlePage;

    private UI.TsumuSelect tsumuSelect;

    private Vector2 startPos;
    private Vector2 endPos;

    private Vector2 initPos;

    private Vector3 posAmount = new Vector3(Constants.SELECT_FLICK_AMOUNT, 0.0f, 0.0f);

    void Start()
    {
        titlePage = gameObject.GetComponent<UI.TitlePage>();
        tsumuSelect = gameObject.GetComponent<UI.TsumuSelect>();
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

    public void StartMove(bool isRight)
    {
        if (tsumuSelect.Flick)
            return;

        tsumuSelect.Right = isRight;
        tsumuSelect.Flick = true;
    }
}
