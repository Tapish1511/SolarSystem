using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] planets;
    public float G = 1f;
    float GUtil;
    float speed = 1;
    public GameObject sun;
    float mass;
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("planet");
        InitialVelocity();
        mass = sun.GetComponent<Rigidbody>().mass;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach(GameObject a in planets)
        {
            foreach(GameObject b in planets)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    Vector3 distance = b.GetComponent<Rigidbody>().position - a.GetComponent<Rigidbody>().position;

                    float magnitude = (G * m1 * m2) / Mathf.Pow(distance.magnitude, 2);
                    Vector3 force = distance.normalized * magnitude;
                    a.GetComponent<Rigidbody>().AddForce(force);
                }
            }
        }
    }//gravity


    void InitialVelocity()
    {
        foreach (GameObject a in planets)
        {
            foreach (GameObject b in planets)
            {
                if (!a.Equals(b))
                {
                    
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    a.transform.LookAt(b.transform);
                    float r = Vector3.Distance(a.transform.position ,b.transform.position);
                    a.GetComponent<Rigidbody>().velocity +=  a.transform.right * Mathf.Sqrt(G * m2 / r) ;
                }
            }
        }
    }


    public void speedUp()
    {
        Time.timeScale = 5;
        Time.fixedDeltaTime = Time.timeScale * .01f;
    }
   
    public void nrmlSpeed()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
