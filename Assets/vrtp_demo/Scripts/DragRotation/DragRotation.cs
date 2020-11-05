using UnityEngine;

namespace vrtp_demo.Scripts.DragRotation
{
    public class DragRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 100f;
        private bool isDragging = false;
        private Rigidbody rb;
    
        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void OnMouseDrag()
        {
            isDragging = true;
        }

        // Update is called once per frame
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
                float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            
                rb.AddTorque(Vector3.down * x);
            }
        }
    }
}
