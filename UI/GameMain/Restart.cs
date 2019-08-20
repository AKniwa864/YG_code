using System.Collections;
using UnityEngine;

namespace UI
{
    public class Restart : MonoBehaviour
    {
        [SerializeField]
        private GameObject pause;

        public void OnClick()
        {
            StartCoroutine(PauseCancel());
        }

        private IEnumerator PauseCancel()
        {
            yield return new WaitForSecondsRealtime(Constants.BUTTON_ANIM_TIME);

            pause.SetActive(false);
        }
    }
}
