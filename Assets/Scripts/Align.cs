using System.Collections;
using UnityEngine;

// 회전을 다루는 클래스

// Ariive 클래스와 같은 원리 (멀어지면 빨라지고 가까워지면 느려짐)

public class Align : AgentBehaviour {

    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        float targetOrientation = target.GetComponent<Agent>().orientation;
        float rotaion = targetOrientation - agent.orientation;
        rotaion = MapToRange(rotaion);
        float rotationSize = Mathf.Abs(rotaion);
        if (rotationSize < targetRadius)
            return steering;
        float targetRotation;
        if (rotationSize > slowRadius)
            targetRotation = agent.maxRotation;
        else
            targetRotation = agent.maxRotation * rotationSize / slowRadius;
        targetRotation *= rotaion / rotationSize;
        steering.angular = targetRotation - agent.rotation;
        steering.angular /= timeToTarget;
        float angularAccel = Mathf.Abs(steering.angular);
        if (angularAccel > agent.maxAngularAccel)
        {
            steering.angular /= angularAccel;
            steering.angular *= agent.maxAngularAccel;
        }
        return steering;
    }
}
