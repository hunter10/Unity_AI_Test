using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockonLaserMotion : MonoBehaviour {

    public float speed = 0.1f;
    public Transform guidePrefab; // 인간이 보기위한것
    Transform start;
    Transform dest;
    Transform movedest;
    bool IsStart = false;

    public BoxCollider boxCollider;
    Vector3 moveVec;

    private void Start()
    {
        start = GameObject.Find("start").transform;
        dest = GameObject.Find("dest").transform;

        movedest = CrateDest();
        //movedest.GetComponent<SpriteRenderer>().enabled = false;
        moveVec = CreateMoveVector();

        int a = 0;
    }

    // 목적지를 생성하기
    Transform CrateDest()
    {
        Transform tr = null;

        // 최종 목적지에서 시작 위치의 벡터에서 일정량만큼 좌우로 벌어진 위치 생성
        //Vector3 guideline = 

        tr = (Transform)Instantiate(guidePrefab,
                                    start.position,
                                    start.rotation);

        // 가려는 축 방향으로 좌우로 3

        tr.position = new Vector3(start.position.x + 3, 
                                  start.position.y, 
                                  start.position.z + 2);
        
        return tr;
    }

    Vector3 CreateMoveVector()
    {
        Vector3 vec = Vector3.zero;

        vec = dest.position - transform.position;

        return vec;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsStart = true;
            
        }

        if (IsStart)
        {
            // 가상의 목표를 원래 목표로 움직이기
            movedest.position = Lerp(movedest.position, dest.position, speed * speed * Time.deltaTime);

            // 가상의 목표 방향으로 움직이기
            moveVec = movedest.position - transform.position;
            transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
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
