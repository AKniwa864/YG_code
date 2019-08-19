using UnityEngine;

namespace UI
{
    public class TitlePage : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] page;

        [SerializeField]
        private GameObject select;

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
            select.SetActive(false);
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
                select.SetActive(true);
            }
        }

        private void PageChanger()
        {
            foreach (GameObject obj in page)
            {
                if (page[(int)currentPage] == obj)
                {
                    page[(int)currentPage].SetActive(true);
                    continue;
                }
                obj.SetActive(false);
            }
        } 
    }
}