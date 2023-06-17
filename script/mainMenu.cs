using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public GameObject bayangan;
    public Slider slider;
    public bool povtarget  = true;


    
 

    public void povmerah()
    {
        bayangan.SetActive(false);
        povtarget = true;

    }

    public void povhijau()
    {
        bayangan.SetActive(true);
        povtarget = false;
    }

    public void jalanterus()
    {
        
    }

    public void stopjalanterus()
    {
        GameObject[] droid = GameObject.FindGameObjectsWithTag("droids");
        foreach (GameObject droids in droid) { }
            
    }





    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
