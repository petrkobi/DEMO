using UnityEngine;

namespace vrtp_demo.Scripts.UI.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WindowDataStatus", menuName = "Data/WindowDataStatus", order = 0)]
    public class WindowDataStatus : ScriptableObject
    {
        public enum WindowStatus
        {
            Intro,
            MainView,
            ColorPickerWindow
        }
        public WindowStatus Window;
        
        
        public delegate void OnChangeDelegate(float value);
        public event OnChangeDelegate OnChange;
        public float lightIntensity;

        public void SetValue(float newValue)
        {
            lightIntensity = newValue;
            if (OnChange != null)
            {
                OnChange(lightIntensity);
            }
        }
        
    }
}