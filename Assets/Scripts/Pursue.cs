using UnityEngine;
using System.Collections;

// Seek : 찾다 
// 타켓 위치에서 - 내 위치 (벡터a - 벡터b = a로 향하는 벡터), (벡터b - 벡터a = b로 향하는 벡터)
// 방향을 정한다음 
// 직선방향으로 최대가속도로 

// Pursue : 추적하다.
// 예측해서 추적하기용 클래스
// 타겟과 타켓의 행동관리자를 구해서 
// 속도가 너무 작다면 최대 예측치로 추적
// 아니라면 타겟과의 거리/속도 비율로 추적

public class Pursue : Seek
{
    public float maxPrediction;
    private GameObject targetAux;
    private Agent targetAgent;

    public override void Awake()
    {
        base.Awake();
        targetAgent = target.GetComponent<Agent>();
        targetAux = target;
        target = new GameObject();
    }

    private void OnDestroy()
    {
        Destroy(targetAux);
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agent.velocity.magnitude;
        float prediction;
        if (speed <= distance / maxPrediction)
		{
            prediction = maxPrediction;
		}
        else
        {
            prediction = distance / speed;
        }
		
		target.transform.position = targetAux.transform.position;
		target.transform.position += targetAgent.velocity * prediction;

        return base.GetSteering();
    }
}
