using UnityEngine;

namespace UI
{
    public class TitlePage : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] page = new GameObject[(int)Constants.TitlePageType.Max];

        [SerializeField]
        private GameObject[] pageObj = new GameObject[(int)Constants.TitlePageType.Max];

        [SerializeField]
        private GameObject[] bg = new GameObject[(int)Constants.TitlePageType.Max];

        [SerializeField]
        private GameObject curtain;

        private Animator curtainAnim;

        private int tempHash;

        private Constants.TitlePageType currentPage = Constants.TitlePageType.Title;
        public Constants.TitlePageType CurrentPage => currentPage;

        void Start()
        {
            curtainAnim = curtain.GetComponent<Animator>();
            PageChanger();
        }

        void Update()
        {
            if (!UnityEngine.Rendering.SplashScreen.isFinished)
                return;

            if (Input.GetMouseButtonDown(0) && currentPage == Constants.TitlePageType.Title)
            {
                curtain.SetActive(true);
                tempHash = curtainAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
            }

            if(curtain.activeSelf)
            {
                if (curtainAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    curtain.SetActive(false);

                if (tempHash == curtainAnim.GetCurrentAnimatorStateInfo(0).fullPathHash)
                    return;

                tempHash = curtainAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
                currentPage = Constants.TitlePageType.TsumuSelect;
                PageChanger();
            }
        }

        private void PageChanger()
        {
            for(int i = 0; i < (int)Constants.TitlePageType.Max; i ++)
            {
                if ((int)currentPage == i)
                {
                    page[i].SetActive(true);
                    pageObj[i].SetActive(true);
                    bg[i].SetActive(true);
                    continue;
                }
                page[i].SetActive(false);
                pageObj[i].SetActive(false);
                bg[i].SetActive(false);
            }
        } 
    }
}