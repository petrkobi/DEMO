using UniRx;
using UnityEngine;
using UnityEngine.UI;
using vrtp_demo.Scripts.Common.Events;
using vrtp_demo.Scripts.UI.Events;

namespace vrtp_demo.Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button changeColorButton;
    
        [Header("Window")] 
        [SerializeField] private GameObject colorPickerWindow;
        [SerializeField] private GameObject mainMenuWindow;

        private void Start()
        {
            //When Receive Request for ColorPickerWindow -> Instantiate ColorPickerWindow under Canvas
            EventDispatcher.Receive<RequestColorPickerWindowEvent>()
                .Subscribe(_ =>
                {
                    Instantiate(colorPickerWindow, canvas.transform);
                });

            //When Receive Request for MainWindow -> Instantiate MainWindow under Canvas
            EventDispatcher.Receive<RequestMainWindowEvent>()
                .Subscribe(_ =>
                {
                    Instantiate(mainMenuWindow, canvas.transform);
                });
        }
        
    }
}
