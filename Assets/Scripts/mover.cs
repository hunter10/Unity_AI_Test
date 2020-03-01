using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class mover : MonoBehaviour {

    
    float speed = 1f;
    public Transform dest;
    bool IsStart = false;

    float delta = 0;
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            IsStart = true;
            //transform.position = transform.position + (dest.position - transform.position);
            //delta = 1f;
        }

        if (IsStart)
        {
            // 1. 해당시간안에 정속도로 움직이기
            //delta += Time.deltaTime;
            //float percent = delta / speed;
            //if (percent > 1f)
            //    percent = 1f;

            // 2. 목표에 가까울수록 느려지기
            //float percent = Time.deltaTime;

            // 3. 목표에 가까울수록 빨라지기(최초에 극히 작은수에서 점점 커지는 함수를 쓰면됨)
            delta += Time.deltaTime;
            float percent = delta;

            transform.position = Lerp(transform.position, dest.position, percent);
        }
	}

    // Step1
    Vector3 Lerp(Vector3 start, Vector3 dest, float t)
    {
        // 여기서 1은 전체 시간의 흐름속에서 100%라는 개념으로 봐야 함.
        Vector3 result = ((1f - t) * start) + (t * dest);

        return result;
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
