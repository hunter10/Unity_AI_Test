using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockonLaserMotion : MonoBehaviour {

    float speed = 1f;
    public Transform dest;
    bool IsStart = false;

    public BoxCollider boxCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsStart = true;
        }

        if (IsStart)
        {
            //transform.position = Lerp(transform.position, dest.position, speed * Time.deltaTime);
            
            transform.Translate(dest.position * speed * Time.deltaTime, Space.World);

            //Vector3 v = transform.position - dest.position;
        }
    }

    Vector3 Lerp(Vector3 start, Vector3 dest, float t)
    {
        return (1f - t) * start + t * dest;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int a = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        int b = 0;
        IsStart = false;
    }
}
