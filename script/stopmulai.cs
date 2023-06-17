using UnityEngine;
using UnityEngine.UI;

public class stopmulai : MonoBehaviour
{
    public Button stopButton;
    private move[] scriptClones;

    private void Start()
    {
        // Attach the stop method to the button click event
        stopButton.onClick.AddListener(StopRepeatingInvoke);

    }

       public void StopRepeatingInvoke()
    {

        // Find all instances of YourScript in the scene
        scriptClones = FindObjectsOfType<move>();
        moveG moveG = FindObjectOfType<moveG>();

        foreach (move move in scriptClones)
        {
            move.CancelInvoke("moveRed");
        }

        moveG.CancelInvoke("moveRed");
        moveG.CancelInvoke("kaburhijau");
    }

}
