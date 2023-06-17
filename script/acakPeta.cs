using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acakPeta : MonoBehaviour
{
    public float horizontalMap;
    public float verticalMap;
    public int numberRan;
    public GameObject lantai;
    public GameObject tembok;
    public Vector3 koordinat;
    public float xkor = -26.5f;
    public float ykor = 14.5f;

    public bool stopimg1 = true;
    public bool stopimg2 = true;
    public bool temboktengah = false;


    public Transform upPos;
    public Transform downPos;
    public Transform leftPos;
    public Transform rightPos;
    public RaycastHit2D hitinfoDown;
    public RaycastHit2D hitinfoUp;
    public RaycastHit2D hitinfoLeft;
    public RaycastHit2D hitinfoRight;
    public float distanceLine = 1f;


    public int Movetime = 1;
    public float movedelay = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("randomMap", Movetime, movedelay);

    }

    public void DestroyObject(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
        stopimg1 = false;

    }






    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(xkor, ykor, 0); ;
        hitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, distanceLine);
        hitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, distanceLine);
        hitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, distanceLine);
        hitinfoRight = Physics2D.Raycast(rightPos.position, transform.right, distanceLine);

    }

  


    private void randomMap()
    {


        if (stopimg1 == false)
        {


            numberRan = Random.Range(1, 5);
            if (numberRan >= 2)
            {
                Instantiate(tembok, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;


                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 13.5f;
                            stopimg2 = false;
                        }

                    }
                   
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 13.5f;
                        stopimg2 = false;
                    }

                }
            }
            else if (numberRan < 2)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 13.5f;
                            stopimg2 = false;
                        }

                    }
                    
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    Debug.Log(xkor);
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 13.5f;
                        stopimg2 = false;
                    }
                }

            }



        }

        else if (temboktengah == true)
        {
            if (hitinfoUp.collider != null && hitinfoDown.collider != null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = false;
                            temboktengah = false;
                        }
                    }
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;
                        temboktengah = false;
                    }

                }
            }

            else if (hitinfoUp.collider == null || hitinfoDown.collider == null)
            {
                if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;
                        temboktengah = false;

                    }

                }
                else
                {
                    temboktengah = false;
                    stopimg2 = false;
                }


                Debug.Log("berhenti");
            }
        }

        else if (stopimg2 == false)
        {
            if (hitinfoUp.collider == null && hitinfoDown.collider == null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }

                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }
            else if (hitinfoUp.collider != null && hitinfoDown.collider != null && hitinfoLeft.collider == null)
            {
                numberRan = Random.Range(1, 9);
                if (numberRan > 1)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (hitinfoRight.collider != null && xkor != 19.5f)
                    {
                        Instantiate(lantai, transform.position, transform.rotation);
                        xkor++;

                        if (xkor == 20.5f)
                        {
                            xkor = -26.5f;
                            ykor -= 2;
                            if (ykor <= -15.5)
                            {
                                stopimg1 = true;
                                xkor = -26.5f;
                                ykor = 14.5f;
                                stopimg2 = true;
                            }

                        }
                    }


                    else if (xkor == 19.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;

                        }

                    }



                }
                else if (numberRan < 2)
                {
                    Instantiate(tembok, transform.position, transform.rotation);
                    xkor++;

                    stopimg2 = true;
                    temboktengah = true;

                    if (hitinfoRight.collider != null && xkor != 19.5f)
                    {
                        Instantiate(lantai, transform.position, transform.rotation);
                        xkor++;

                        if (xkor == 20.5f)
                        {
                            xkor = -26.5f;
                            ykor -= 2;
                            if (ykor <= -15.5)
                            {
                                stopimg1 = true;
                                xkor = -26.5f;
                                ykor = 14.5f;
                                stopimg2 = true;
                            }

                        }
                    }


                    else if (xkor == 19.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        Debug.Log(xkor);
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;

                        }
                    }

                }
            }

            else if (hitinfoUp.collider == null && hitinfoDown.collider != null && hitinfoLeft.collider == null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;
                  

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }

            else if (hitinfoUp.collider == null && hitinfoDown.collider != null && hitinfoLeft.collider != null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;
                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }

            else if (hitinfoUp.collider != null && hitinfoDown.collider == null && hitinfoLeft.collider == null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }

            else if (hitinfoUp.collider != null && hitinfoDown.collider == null && hitinfoLeft.collider != null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }


                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }

            else if (hitinfoUp.collider != null && hitinfoDown.collider != null && hitinfoLeft.collider != null)
            {
                Instantiate(lantai, transform.position, transform.rotation);
                xkor++;

                if (hitinfoRight.collider != null && xkor != 19.5f)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (xkor == 20.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;
                        }

                    }
                }

                else if (xkor == 19.5f)
                {
                    xkor = -26.5f;
                    ykor -= 2;
                    if (ykor <= -15.5)
                    {
                        stopimg1 = true;
                        xkor = -26.5f;
                        ykor = 14.5f;
                        stopimg2 = true;

                    }

                }
            }
            else
            {
                numberRan = Random.Range(1, 7);
                if (numberRan <= 3)
                {
                    Instantiate(tembok, transform.position, transform.rotation);
                    xkor++;

                    if (hitinfoRight.collider != null && xkor != 19.5f)
                    {
                        Instantiate(lantai, transform.position, transform.rotation);
                        xkor++;

                        if (xkor == 20.5f)
                        {
                            xkor = -26.5f;
                            ykor -= 2;
                            if (ykor <= -15.5)
                            {
                                stopimg1 = true;
                                xkor = -26.5f;
                                ykor = 14.5f;
                                stopimg2 = true;
                            }

                        }
                    }


                    else if (xkor == 19.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;

                        }

                    }
                }
                else if (numberRan > 1)
                {
                    Instantiate(lantai, transform.position, transform.rotation);
                    xkor++;

                    if (hitinfoRight.collider != null && xkor != 19.5f)
                    {
                        Instantiate(lantai, transform.position, transform.rotation);
                        xkor++;

                        if (xkor == 20.5f)
                        {
                            xkor = -26.5f;
                            ykor -= 2;
                            if (ykor <= -15.5)
                            {
                                stopimg1 = true;
                                xkor = -26.5f;
                                ykor = 14.5f;
                                stopimg2 = true;
                            }

                        }
                    }

                    else if (xkor == 19.5f)
                    {
                        xkor = -26.5f;
                        ykor -= 2;
                        Debug.Log(xkor);
                        if (ykor <= -15.5)
                        {
                            stopimg1 = true;
                            xkor = -26.5f;
                            ykor = 14.5f;
                            stopimg2 = true;

                        }
                    }

                }

            }


        }



    }
}
