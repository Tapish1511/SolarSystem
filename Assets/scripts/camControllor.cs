using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControllor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    public Camera cam;
    public GameObject[] planets;
    Transform mypos;
    int count = 1;
    float distance = 50f;
    
    public Vector3 offset = new Vector3(0f, 0f, -180f);
    void Start()
    {
        mypos = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Zoom();
        Enlarge();
        

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
        if (Input.GetAxisRaw("Vertical") > 0 && (cam.transform.position - mypos.position).magnitude > 100f)
        {
            Vector3 pos1 = mypos.position;
            Vector3 pos2 = cam.transform.position;
            Vector3 directon = pos2.normalized;
            float magnitude = (pos2 - pos1).magnitude;
            magnitude -= distance * Time.deltaTime;
            pos2 = magnitude * directon;
            cam.transform.position = pos2;
        }
        else if (Input.GetAxisRaw("Vertical") < 0 && (cam.transform.position - mypos.position).magnitude < 6500f)
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
    void Enlarge()
    {
        if ((cam.transform.position - mypos.position).magnitude > 1000f && count > 0)
        {
            foreach (GameObject planet in planets)
            {
                float x = planet.transform.localScale.x;
                float y = planet.transform.localScale.y;
                float z = planet.transform.localScale.z;
                x *= 2.5f;
                y *= 2.5f;
                z *= 2.5f;
                planet.transform.localScale = new Vector3(x, y, z);

            }
            count--;
            distance = 500f;
        }
        if ((cam.transform.position - mypos.position).magnitude < 1000f && count == 0)
        {
            foreach (GameObject planet in planets)
            {
                float x = planet.transform.localScale.x;
                float y = planet.transform.localScale.y;
                float z = planet.transform.localScale.z;
                x /= 2.5f;
                y /= 2.5f;
                z /= 2.5f;
                planet.transform.localScale = new Vector3(x, y, z);
            }
            count++;
            distance = 50f;
        }

    }



   
}
