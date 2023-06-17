using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopstart : MonoBehaviour
{
    move move;
    moveG moveG;

    public float Movetime;
    public float movedelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void jalan()
    {
        move.InvokeRepeating("moveRed", Movetime, movedelay);
        moveG.InvokeRepeating("moveRed", Movetime, movedelay);

    }

    public void berhenti()
    {
        move.stopMove = false;
        moveG.stopMove = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
