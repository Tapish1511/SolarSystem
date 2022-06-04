using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject obj;
    Transform mypos;
    Vector3 prePosition;
    float distance = 500f;
    void Start()
    {
        mypos = obj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Zoom();

    }

    private void move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prePosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = prePosition - cam.ScreenToViewportPoint(Input.mousePosition);
            float distance = (cam.transform.position - obj.transform.position).magnitude;
            cam.transform.position = obj.transform.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(0, 0, -distance);
            prePosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    void Zoom()
    {
        if ((cam.transform.position - mypos.position).magnitude > 800f) distance = 5000f;
        else distance = 750f;
        if (Input.mouseScrollDelta.y > 0 && (cam.transform.position - mypos.position).magnitude > 100f)
        {
            Vector3 pos1 = mypos.position;
            Vector3 pos2 = cam.transform.position;
            Vector3 directon = pos2.normalized;
            float magnitude = (pos2 - pos1).magnitude;
            magnitude -= distance * Time.deltaTime;
            pos2 = magnitude * directon;
            cam.transform.position = pos2;
        }
        else if (Input.mouseScrollDelta.y < 0 && (cam.transform.position - mypos.position).magnitude < 6500f)
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
