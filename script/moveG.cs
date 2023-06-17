using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveG : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform upPos;
    public Transform downPos;
    public Transform rightPos;
    public Transform leftPos;

    public float jarakx ;
    public float jaraky;
    public Vector2 hijaut;
    public Vector2 meraht;

    public GameObject[] merah;

    public RaycastHit2D hitinfoRight;
    public RaycastHit2D hitinfoLeft;
    public RaycastHit2D hitinfoUp;
    public RaycastHit2D hitinfoDown;


    public bool stopMove = false;
    public bool larihijau = false;
    public GameObject merahpre;

    public float Movetime;
    public float movedelay;
    public float distanceLine = 1f;
    int RandomArah;

    //public GameObject scriptmerah;
  

    void Start()
    {
        InvokeRepeating("moveRed", Movetime, movedelay);
        InvokeRepeating("kaburhijau", Movetime, movedelay);
        Physics2D.queriesStartInColliders = false;
       
        merah = GameObject.FindGameObjectsWithTag("Player");

    }

 
    // Update is called once per frame
    void Update()
    {
      


        hitinfoRight = Physics2D.Raycast(rightPos.position, transform.right, distanceLine);
        hitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, distanceLine);
        hitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, distanceLine);
        hitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, distanceLine);


        /*if (hitinfoDown.collider != null)
        {
            Debug.DrawLine(rightPos.position, rightPos.position , Color.red);
        }
        else if(hitinfoDown.collider == null)
        {
            Debug.DrawLine(rightPos.position , rightPos.position , Color.green);
        }*/
    }

    void ceklarihijau()
    {
        hijaut = transform.position;
        foreach (GameObject merahpre in merah)
        {
            meraht = merahpre.transform.position;
        }

        jarakx = meraht.x - hijaut.x;
        jaraky = meraht.y - hijaut.y;
        jarakx = Mathf.Abs(jarakx);
        jaraky = Mathf.Abs(jaraky);
        if (jarakx <8  &&  jaraky < 8)
        {
            stopMove = false;
            larihijau = true;
        }
        else if (jarakx > 8 || jaraky > 8)
        {
            stopMove = true;
            larihijau = false;
        }
    }

    void kaburhijau()
    {
       if(larihijau == true)
        {
        
            if (meraht.x < hijaut.x)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);
                    ceklarihijau();
               

                }
                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                    ceklarihijau();
                    if (jarakx > 8 && jaraky > 8)
                    {
                        stopMove = true;
                        larihijau = false;
                    }
                }

                else if (RandomArah == 3 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                    ceklarihijau();
                    if (jarakx > 8 && jaraky > 8)
                    {
                        stopMove = true;
                        larihijau = false;
                    }
                }
            }

            else if (meraht.y < hijaut.y)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);
                    ceklarihijau();
                 

                }

                else if (RandomArah == 2 && hitinfoRight.collider == null)
                {

                    transform.Translate(1, 0, 0);
                    ceklarihijau();
                  
                }


                else if (RandomArah == 3 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                    ceklarihijau();
                }
            }

            else if (meraht.x > hijaut.x)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);
                    ceklarihijau();
                 

                }

                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                    ceklarihijau();
                
                }


                else if (RandomArah == 3 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                    ceklarihijau();
                
                }
            }

            else if (meraht.y > hijaut.y)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoDown.collider == null)
                {
                    transform.Translate(0, -1, 0);
                    ceklarihijau();
                 

                }

                else if (RandomArah == 2 && hitinfoRight.collider == null)
                {

                    transform.Translate(1, 0, 0);
                    ceklarihijau();
                 
                }


                else if (RandomArah == 3 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                    ceklarihijau();
                  
                }
            }
        }
    }


    public void moveRed()
    {
        if (stopMove)
        {
            ceklarihijau();
            if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 5);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }

                else if (RandomArah == 3 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }

                else if (RandomArah == 4 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                transform.Translate(0, -1, 0);
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                transform.Translate(0, 1, 0);
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                transform.Translate(1, 0, 0);
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                transform.Translate(-1, 0, 0);
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 3 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }

                else if (RandomArah == 2 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }

                else if (RandomArah == 3 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }
            }



            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }


                else if (RandomArah == 3 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 4);
                //Debug.Log(RandomArah);

                if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }

                else if (RandomArah == 3 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }

                else if (RandomArah == 1 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }


            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }

            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);

                if (RandomArah == 1 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }

                else if (RandomArah == 2 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);
                if (RandomArah == 1 && hitinfoUp.collider == null)
                {
                    transform.Translate(0, 1, 0);

                }

                else if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }


            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);


                if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }

                else if (RandomArah == 1 && hitinfoRight.collider == null)
                {
                    transform.Translate(1, 0, 0);
                }
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                RandomArah = Random.Range(1, 3);
                //Debug.Log(RandomArah);


                if (RandomArah == 2 && hitinfoDown.collider == null)
                {

                    transform.Translate(0, -1, 0);
                }


                else if (RandomArah == 1 && hitinfoLeft.collider == null)
                {
                    transform.Translate(-1, 0, 0);
                }
            }

           
        }

    }
}
