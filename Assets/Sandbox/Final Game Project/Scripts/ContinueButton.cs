using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public void ResumeButtonClicked()
    {
            FindObjectOfType<PauseGame>().ResumeGame(); // Find the PauseGame script and call ResumeGame method
    }
    
}
