using System.Collections;
using UnityEngine;

// 에이전트의 이동 및 회전을 저장하기 위한 사용자 정의 데이터
public class Steering 
{
	public float angualr;
	public Vector3 linear;
	public Steering()
	{
		angualr = 0.0f;
		linear = new Vector3();
	}
}
