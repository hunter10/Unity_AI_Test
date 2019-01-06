using System.Collections;
using UnityEngine;

// Seek : 찾다 
// 타켓 위치에서 - 내 위치 (벡터a - 벡터b = a로 향하는 벡터), (벡터b - 벡터a = b로 향하는 벡터)
// 방향을 정한다음 
// 직선방향으로 최대가속도로 

public class Seek : AgentBehaviour {
	public override Steering GetSteering()
	{
		Steering steering = new Steering();
		steering.linear = target.transform.position - transform.position;
		steering.linear.Normalize();
		steering.linear = steering.linear * agent.maxAccel;
		return steering;
	}
}
