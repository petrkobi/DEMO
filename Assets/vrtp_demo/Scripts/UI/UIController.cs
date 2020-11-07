using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private Button changeColorButton;
    
    // Start is called before the first frame update
    void Start()
    {
        changeColorButton.onClick.AddListener(OnClickChangeColorButton);
    }

    private void OnClickChangeColorButton()
    {
        
    }


}
