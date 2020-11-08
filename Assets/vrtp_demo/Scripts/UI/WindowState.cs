using UnityEngine;

namespace vrtp_demo.Scripts.UI
{
    [CreateAssetMenu(fileName = "WindowDataStatus", menuName = "Data/WindowDataStatus", order = 0)]
    public class WindowDataStatus : ScriptableObject
    {
        public enum WindowStatus
        {
            MainView,
            ColorPickerWindow
        }

        public WindowStatus Window;
    }
}