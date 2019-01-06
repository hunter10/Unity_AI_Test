using System.Collections;
using UnityEngine;

public class Arrive : AgentBehaviour 
{
	public float targetRadius;
	public float slowRadius;
	public float timeToTarget = 0.1f;

	public override Steering GetSteering()
	{
		// 두 반경 변수들에 따른 대상과의 거리에 의존해 적합한 속도를 계산 
		Steering steering = new Steering();
		Vector3 direction = target.transform.position - transform.position;
		float distance = direction.magnitude;
		float targetSpeed;
		if(distance < targetRadius)
			return steering;
		
		if(distance > slowRadius)
			targetSpeed = agent.maxSpeed;
		else
		{
			targetSpeed = agent.maxSpeed * distance / slowRadius;
		}

		// steering	값을 설정하고, 최대 속도에 맞춰 값을 제한하는 코드 
		Vector3 desiredVelocity = direction;
		desiredVelocity.Normalize();
		desiredVelocity *= targetSpeed;
		steering.linear = desiredVelocity - agent.velocity;
		steering.linear /= timeToTarget;
		if(steering.linear.magnitude > agent.maxAccel) {
			steering.linear.Normalize();
			steering.linear *= agent.maxAccel;
		}

		return steering;
	}
}
