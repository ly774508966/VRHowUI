using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;

        void OnEnable()
        {
            Debug.Log("OnEnable " + Name);
        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
            Debug.Log("SetDownState " + Name);
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
            Debug.Log("SetUpState " + Name);
        }

        public void SetClieckState()
        {
            Debug.Log("SetClieckState " + Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
