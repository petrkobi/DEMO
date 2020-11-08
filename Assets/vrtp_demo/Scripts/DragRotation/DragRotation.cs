using UnityEngine;
using vrtp_demo.Scripts.UI.ScriptableObjects;

namespace vrtp_demo.Scripts.DragRotation
{
    public class DragRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;

        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;

        private bool isDragging = false;
        private Rigidbody rb;

        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void OnMouseDrag()
        {
            isDragging = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }

        private void FixedUpdate()
        {
            if (isDragging)
            {
                //if (_windowDataStatus.WindowStatus == Constants.WindowStatusColorPicker) return;
                if (_windowDataStatus.Window == WindowDataStatus.WindowStatus.ColorPickerWindow) return;
                
                float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
                rb.AddTorque(Vector3.down * x);
            }
            
            rb.transform.eulerAngles = new Vector3(0,rb.transform.eulerAngles.y, 0);
        }
    }
}