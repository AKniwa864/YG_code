using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SwitchActive : MonoBehaviour
    {
        [SerializeField]
        private GameObject obj;

        public void Switch()
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
}
