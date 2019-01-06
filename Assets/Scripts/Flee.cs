using System.Collections;
using UnityEngine;

// Flee : 달아나다
// 내 위치에서 - 타켓 위치를 구하고 (벡터a - 벡터b = a로 향하는 벡터), (벡터b - 벡터a = b로 향하는 벡터)
// 방향을 정한다음 
// 직선방향으로 최대가속도로 
public class Flee : AgentBehaviour 
{
	public override Steering GetSteering()
	{
		Steering steering = new Steering();
		steering.linear = transform.position - target.transform.position;
		steering.linear.Normalize();
		steering.linear = steering.linear * agent.maxAccel;
		return steering;
	}

}
