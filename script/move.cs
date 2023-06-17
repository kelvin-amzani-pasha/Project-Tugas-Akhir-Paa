using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class move : MonoBehaviour
{
    // Start is called before the first frame update

    public bool aktivkan = false;
    stopmulai stopmulai;

    public Transform upPos;
    public Transform downPos;
    public Transform rightPos;
    public Transform leftPos;

    public GameObject[] hijau;
    



    public RaycastHit2D hitinfoRight;
    public RaycastHit2D hitinfoLeft;
    public RaycastHit2D hitinfoUp;
    public RaycastHit2D hitinfoDown;

    public RaycastHit2D lhitinfoRight;
    public RaycastHit2D lhitinfoLeft;
    public RaycastHit2D lhitinfoUp;
    public RaycastHit2D lhitinfoDown;

    public bool stopMove= false;
    public bool stopkanan = true;
    public bool stopkiri = true;

   float tujuan;
    Vector2 sampai;

    public bool kanan = false;
    public bool kiri =  false;
    public bool atas =  false;
    public bool bawah = false;

    bool jalan = true;
    public int tujuan1;



    public float Movetime;
    public float movedelay;
    public float distanceLine = 1f;
    public int linelong = 50;
    int RandomArah;

    void Start()
    {
        InvokeRepeating("moveRed", Movetime, movedelay);
        InvokeRepeating("kananterus", Movetime, movedelay);
        InvokeRepeating("kiriterus", Movetime, movedelay);
        Physics2D.queriesStartInColliders = false;


        hijau = GameObject.FindGameObjectsWithTag("droids");

        stopmulai = GetComponent<stopmulai>();


    }

    

    // Update is called once per frame
    void Update()
    {
        lhitinfoRight = Physics2D.Raycast(rightPos.position, transform.right, linelong);
        lhitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, linelong);
        lhitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, linelong);
        lhitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, linelong);


        hitinfoRight = Physics2D.Raycast(rightPos.position , transform.right, distanceLine);
        hitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, distanceLine);
        hitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, distanceLine);
        hitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, distanceLine);


        foreach (GameObject green in hijau)
        {
            Debug.Log(transform.position);
            Debug.Log(green.transform.position);
            if (transform.position == green.transform.position)
            {
                
                stopmulai.StopRepeatingInvoke();
            }
        }




    }
 

    void checkhijau()
    {
        jalan = false;
        if (lhitinfoUp.collider.CompareTag("droids"))
        {

            stopMove = false;
            tujuan = transform.position.y - lhitinfoUp.point.y + 0.5f;
            tujuan.ToString("0");
            tujuan = Mathf.Abs(tujuan);
            tujuan.ToString("0");
            tujuan1 = (int)tujuan;
            atas = true;
                if (atas == true)
                {
                    Debug.Log(tujuan);
                    StartCoroutine(MoveUp());
                }
            
        }
        else if (lhitinfoDown.collider.CompareTag("droids"))
        {
            
                stopMove = false;
                tujuan = transform.position.y - lhitinfoDown.point.y + 0.5f;
            tujuan.ToString("0");
            tujuan = Mathf.Abs(tujuan);
            tujuan.ToString("0");
            tujuan1 = (int)tujuan;
            bawah = true;
                if (bawah == true)
                {
                    Debug.Log(tujuan);
                    StartCoroutine(MoveDown());
                }
            

        }

        else if (lhitinfoRight.collider.CompareTag("droids"))
        {
           
                stopMove = false;
                tujuan = transform.position.x - lhitinfoRight.point.x + 0.5f;
            tujuan.ToString("0");
            tujuan = Mathf.Abs(tujuan);
                tujuan.ToString("0");
            tujuan1 = (int)tujuan;
            kanan = true;
                if (kanan == true)
                {
                    Debug.Log(tujuan);
                    StartCoroutine(MoveRight());
                }
            
        }
        else if (lhitinfoLeft.collider.CompareTag("droids"))
        {
            if (lhitinfoLeft.collider.CompareTag("droids"))
            {
                stopMove = false;
                tujuan = transform.position.x - lhitinfoLeft.point.x + 0.5f;
                tujuan.ToString("0");
                tujuan = Mathf.Abs(tujuan);
                tujuan.ToString("0");
                tujuan1 = (int)tujuan;
                kiri = true;
                if (kiri == true)
                {
                    Debug.Log(tujuan);
                    StartCoroutine(MoveLeft());
                }
            }
        }
        else
        {
            jalan = true;
        }
    }
    private IEnumerator MoveUp()
    {
        for (int i =tujuan1; i >=0; i--)
        {
            Debug.Log("jalan :" + i);
            transform.Translate(0, 1, 0);
            yield return new WaitForSeconds(.5f); // Add a delay of 1 second
            if(i==0 )
            {
                Debug.Log("tujuan = "+tujuan);
                Debug.Log("i = "+i);
                atas = false;
                stopMove = true;
                jalan = true;
            }
        }
    }

    private IEnumerator MoveDown()
    {
        for (int i = tujuan1; i >= 0; i--)
        {
            Debug.Log("jalan :" + i);
            transform.Translate(0, -1, 0);
            yield return new WaitForSeconds(.5f); // Add a delay of 1 second
            if (i == 0)
            {
                Debug.Log("tujuan = "+tujuan);
                Debug.Log("i = "+i);
                bawah = false;
                stopMove = true;
                jalan = true;
            }
        }
    }

    private IEnumerator MoveRight()
    {
        for (int i = tujuan1; i >=0; i--)
        {
            Debug.Log("jalan :" + i);
            transform.Translate(1, 0, 0);
            yield return new WaitForSeconds(.5f); // Add a delay of 1 second

            if (i == 0)
            {
                Debug.Log( "tujuan= " + tujuan);
                Debug.Log("i = " +i);
                kanan = false;
                stopMove = true;
                jalan = true;
            }
        }
    }

    private IEnumerator MoveLeft()
    {
        for (int i = tujuan1; i >=0; i--)
        {
            Debug.Log("jalan :" + i);
            transform.Translate(-1, 0, 0);
            yield return new WaitForSeconds(.5f); // Add a delay of 1 second
            if (i == 0)
            {
                Debug.Log("tujuan = "+tujuan);
                Debug.Log("i = "+i);
                kiri = false;
                stopMove = true;
                jalan = true;
            }
        }
    }

    public void moveRed()
    {
        

        if (stopMove)
        {
            
           if(hitinfoUp.collider==null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 5);
                    //Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 3 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 4 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
               
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 4);
                    Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }

                    }

                    else if (RandomArah == 3 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 2 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
               
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 4);
                    //Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }

                    }

                    else if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 3 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
               
            }

            

            else  if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 4);
                   // Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }

                    }

                    else if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }


                    else if (RandomArah == 3 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
               
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 4);
                    //Debug.Log(RandomArah);

                    if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 3 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 1 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
                
            }


            else if (hitinfoUp.collider == null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                    //Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }

                    }

                    else if (RandomArah == 2 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
               

            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                    //Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }

                    }

                    else if (RandomArah == 2 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
             
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                    //Debug.Log(RandomArah);

                    if (RandomArah == 1 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 2 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
              
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                checkhijau();
                if (jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                    //Debug.Log(RandomArah);
                    if (RandomArah == 1 && hitinfoUp.collider == null)
                    {
                        transform.Translate(0, 1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                    //Debug.Log(RandomArah);

                    if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }

                    else if (RandomArah == 1 && hitinfoRight.collider == null)
                    {
                        transform.Translate(1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
                
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    RandomArah = Random.Range(1, 3);
                   // Debug.Log(RandomArah);

                    if (RandomArah == 2 && hitinfoDown.collider == null)
                    {

                        transform.Translate(0, -1, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }


                    else if (RandomArah == 1 && hitinfoLeft.collider == null)
                    {
                        transform.Translate(-1, 0, 0);
                        if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                        {
                            checkhijau();
                        }
                    }
                }
                
            }

            else if(hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider == null)
            {
                checkhijau();
                if(jalan == true)
                {
                    transform.Translate(0, -1, 0);
                    if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                    {
                        checkhijau();
                    }
                }
             
            }

            else if (hitinfoUp.collider == null && hitinfoRight.collider != null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    transform.Translate(0, 1, 0);
                    if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                    {
                        checkhijau();
                    }
                }
             
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider == null && hitinfoLeft.collider != null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    transform.Translate(1, 0, 0);
                    if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                    {
                        checkhijau();
                    }
                }
             
            }

            else if (hitinfoUp.collider != null && hitinfoRight.collider != null && hitinfoLeft.collider == null && hitinfoDown.collider != null)
            {
                checkhijau();
                if(jalan == true)
                {
                    transform.Translate(-1, 0, 0);
                    if (lhitinfoUp.collider != null || lhitinfoRight.collider != null || lhitinfoLeft.collider != null || lhitinfoDown.collider != null)
                    {
                        checkhijau();
                    }
                }
              
            }


        }
        
    }

   
       
         
                
               
                
            
        
   
    /*  void kananterus()
      {
          if(stopkanan == false)
          {
              transform.Translate(1, 0, 0);
          }
          else if(hitinfoUp.collider == null || hitinfoDown.collider == null)
          {
              stopMove = true;
          }

      }

      void kiriterus()
      {
          if(stopkiri == false)
          {
              transform.Translate(-1, 0, 0);
          }
          else if (hitinfoUp.collider == null || hitinfoDown.collider == null)
          {
              stopMove = true;
          }

      }*/
}
