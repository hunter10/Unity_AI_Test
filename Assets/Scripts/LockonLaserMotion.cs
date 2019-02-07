using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockonLaserMotion : MonoBehaviour {

    float speed = 0.1f;
    public Transform guidePrefab; // 인간이 보기위한것
    Transform dest;
    Transform movedest;
    bool IsStart = false;

    public BoxCollider boxCollider;


    private void Start()
    {
        dest = GameObject.Find("dest").transform;
        
        int a = 0;
    }

    // 목적지를 생성하기
    Transform CrateDest()
    {
        Transform tr = null;

        // 최종 목적지에서 시작 위치의 벡터에서 일정량만큼 좌우로 벌어진 위치 생성
        //Vector3 guideline = 

        tr = (Transform)Instantiate(guidePrefab, dest.position, dest.rotation);

        return tr;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsStart = true;
            dest = CrateDest();
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
