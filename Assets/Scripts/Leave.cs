﻿using System.Collections;
using UnityEngine;

public class Leave : AgentBehaviour 
{	
	public float escapeRadius;
	public float dangerRadius;
	public float timeToTarget = 0.1f;

	public override Steering GetSteering()
	{
		// 두 반경 변수들에 따른 대상과의 거리에 의존해 적합한 속도를 계산 
		Steering steering = new Steering();
		Vector3 direction = transform.position - target.transform.position;
		float distance = direction.magnitude;
		if(distance > dangerRadius)
			return steering;
		
		float reduce;
		if(distance < escapeRadius)
			reduce = 0f;
		else
		{
			reduce = distance / dangerRadius * agent.maxSpeed;
		}
		float targetSpeed = agent.maxSpeed - reduce;

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
