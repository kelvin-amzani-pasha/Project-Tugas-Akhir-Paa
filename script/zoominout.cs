using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoominout : MonoBehaviour
{
    Camera maincamera;
    public float zoomout = 15f;
    // Start is called before the first frame update
    void Start()
    {
        maincamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        maincamera.orthographicSize = zoomout;
    }

    public void sliderzoom( float zoom)
    {
        zoomout = zoom;
    }
}
