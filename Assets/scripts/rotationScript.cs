using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform pos;
    public float speed = 1f;
    void Start()
    {
        pos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        pos.Rotate(new Vector3(0f, 1f, 0f), -180 * Time.deltaTime * speed);
    }
}
