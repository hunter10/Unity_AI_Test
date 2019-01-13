using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    public MeshCollider ColliderForRayCast;
    public Transform Player;
    public Transform target;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hitInfo;
            //ColliderForRayCast.Raycast(ray, out hitInfo, 100f);

            //Ease easeX = Ease.Linear;
            //Player.DOMove(target.position, 1f);
        }
    }
}
