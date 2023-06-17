using UnityEngine;
using UnityEngine.UI;

public class mulai : MonoBehaviour
{
    public Button stopButton;
    private move[] scriptClones;

    private void Start()
    {
        // Attach the stop method to the button click event
        stopButton.onClick.AddListener(startRepeatingInvoke);

    }

 

    private void startRepeatingInvoke()
    {
        scriptClones = FindObjectsOfType<move>();
        moveG moveG = FindObjectOfType<moveG>();

        foreach (move move in scriptClones)
        {
            move.InvokeRepeating("moveRed", move.Movetime, move.movedelay);
        
        }
        moveG.InvokeRepeating("moveRed", moveG.Movetime, moveG.movedelay);
        moveG.InvokeRepeating("kaburhijau", moveG.Movetime, moveG.movedelay);
    }
}
