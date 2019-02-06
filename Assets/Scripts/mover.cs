using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class mover : MonoBehaviour {

    
    float speed = 1f;
    public Transform dest;
    bool IsStart = false;
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            IsStart = true;
        }

        if(IsStart)
            transform.position = Lerp(transform.position, dest.position, speed * Time.deltaTime);    	
	}

    // Step1
    Vector3 Lerp(Vector3 start, Vector3 dest, float t)
    {
        return (1f - t) * start + t * dest;
    }
    

    /*
    public Transform sunrise;
    public Transform sunset;
    public float journeyTime = 1.0f;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        Vector3 center = (sunrise.position + sunset.position) * 0.5f;
        center -= new Vector3(1f, 0, 0);

        Vector3 riseRelCenter = sunrise.position - center;
        Vector3 setRelCenter = sunset.position - center;
        float fracComplete = (Time.time - startTime) / journeyTime;

        //transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        //transform.position += center;

        Vector3 pos = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        pos += center;

        transform.DOMove(pos, 0.5f);
    }
    */
}
