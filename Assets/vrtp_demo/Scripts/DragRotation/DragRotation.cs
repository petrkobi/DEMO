using UnityEngine;
using vrtp_demo.Scripts.UI.ScriptableObjects;

namespace vrtp_demo.Scripts.DragRotation
{
    /// <summary>
    ///  Dragging Mazda with Mouse, used Physics dragging, for really nice ending easing
    ///  When Tail-door is open, mixed rotation axis/forces to car, set Rotation to (0,Y,0)
    /// </summary>
    public class DragRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;

        [Header("Data")]
        [SerializeField] private WindowDataStatus _windowDataStatus;

        private bool isDragging = false;
        private Rigidbody rb;
        
        private void Start()
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
                if (_windowDataStatus.Window == WindowDataStatus.WindowStatus.ColorPickerWindow) return;
                
                float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
                rb.AddTorque(Vector3.down * x);
            }
            
            rb.transform.eulerAngles = new Vector3(0,rb.transform.eulerAngles.y, 0);
        }
    }
}