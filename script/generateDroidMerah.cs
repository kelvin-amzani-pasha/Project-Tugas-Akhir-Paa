using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateDroidMerah : MonoBehaviour
{

    public Transform upPos;
    public Transform downPos;
    public Transform rightPos;
    public Transform leftPos;

    public GameObject droidmerah;

    public RaycastHit2D hitinfoRight;
    public RaycastHit2D hitinfoLeft;
    public RaycastHit2D hitinfoUp;
    public RaycastHit2D hitinfoDown;

    public bool summon = false;

    public float xkor;
    public float yxor;

    public float Movetime;
    public float movedelay;
    public int randomjalan;

    public GameObject button;

    public float distanceLine = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("summoningRed", Movetime, movedelay);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        hitinfoRight = Physics2D.Raycast(rightPos.position, transform.right, distanceLine);
        hitinfoLeft = Physics2D.Raycast(leftPos.position, leftPos.transform.right, distanceLine);
        hitinfoUp = Physics2D.Raycast(upPos.position, upPos.transform.right, distanceLine);
        hitinfoDown = Physics2D.Raycast(downPos.position, downPos.transform.right, distanceLine);

    }

    public void startgame()
    {
        summon = true;
        summon = true;
        button.SetActive(false);
    }

    public void tambahdroidmerah()
    {
        summon = true;
    }
    void summoningRed()
    {
        
        if (summon)
        {
            xkor = Random.Range(-27,18);
            yxor = Random.Range(-15,14);

            transform.position = new Vector3(xkor + .5f,yxor + .5f,0);
           

            if (hitinfoDown.collider == null)
            {
                Vector3 lokasi = new Vector3(transform.position.x , transform.position.y - 1, 0);
                Instantiate(droidmerah, lokasi, transform.rotation);
            
                summon = false;
            }

            else if (hitinfoLeft.collider == null)
            {
                Vector3 lokasi = new Vector3(transform.position.x - 1, transform.position.y, 0);
                Instantiate(droidmerah, lokasi, transform.rotation);
              
                summon = false;
            }
            else if (hitinfoRight.collider == null)
            {
                Vector3 lokasi = new Vector3(transform.position.x + 1, transform.position.y, 0);
                Instantiate(droidmerah, lokasi, transform.rotation);

                summon = false;
            }
            else if (hitinfoUp.collider == null)
            {
                Vector3 lokasi = new Vector3(transform.position.x , transform.position.y + 1, 0);
                Instantiate(droidmerah, lokasi, transform.rotation);

                summon = false;
            }
            else
            {
                randomjalan = Random.Range(1, 5);
                if (randomjalan == 1)
                {
                    transform.Translate(1,0,0);
                }

                else if (randomjalan == 2)
                {
                    transform.Translate(-1, 0, 0);
                }
                else if (randomjalan == 3)
                {
                    transform.Translate(0, 1, 0);
                }

                else if (randomjalan == 4)
                {
                    transform.Translate(0, -1, 0);
                }

            }
           
        }
       


    }
}
