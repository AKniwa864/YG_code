using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Pause : MonoBehaviour
    {
        void OnEnable()
        {
            Time.timeScale = 0.0f;
        }

        void OnDisable()
        {
            Time.timeScale = 1.0f;
        }
    }
}
