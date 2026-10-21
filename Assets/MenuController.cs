using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;       // Declares a menu object

    void Start()
    {
        menuCanvas.SetActive(false);                            // Sets menu visibility to false
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))                      // If the Tab key input was pressed
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);           // Sets menu visibility to true
        }
        
    }
}
