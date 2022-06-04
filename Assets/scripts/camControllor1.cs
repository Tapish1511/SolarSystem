using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControllor1 : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Camera cam;
    
    Transform mypos;
    int count = 1;
    float distance = 50f;
    
    
    void Start()
    {
        mypos = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
            

    }

    void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            mypos.Rotate(new Vector3(0, 1, 0), 30 * Time.deltaTime, Space.World);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            mypos.Rotate(new Vector3(0, 1, 0), -30 * Time.deltaTime, Space.World);

        }
    }

    void Zoom()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && (cam.transform.position - mypos.position).magnitude > 3f)
        {
            Vector3 pos1 = mypos.position;
            Vector3 pos2 = cam.transform.position;
            Vector3 directon = pos2.normalized;
            float magnitude = (pos2 - pos1).magnitude;
            magnitude -= distance * Time.deltaTime;
            pos2 = magnitude * directon;
            cam.transform.position = pos2;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && (cam.transform.position - mypos.position).magnitude < 20f)
        {
            Vector3 pos1 = mypos.position;
            Vector3 pos2 = cam.transform.position;
            Vector3 directon = pos2.normalized;
            float magnitude = (pos2 - pos1).magnitude;
            magnitude += distance * Time.deltaTime;
            pos2 = magnitude * directon;
            cam.transform.position = pos2;
        }
    }
    
   
}
