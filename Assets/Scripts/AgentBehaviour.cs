using System.Collections;
using UnityEngine;

// 대부분의 행위에 대한 템플릿 클래스 

public class AgentBehaviour : MonoBehaviour 
{
	public GameObject target;
	protected Agent agent;
    
	public virtual void Awake() {
		agent = gameObject.GetComponent<Agent>();
	}
	// Update is called once per frame
	public virtual void Update () {
		agent.SetSteering(GetSteering());
	}

	public virtual Steering GetSteering()
	{
		return new Steering();
	}

    public float MapToRange(float rotaion)
    {
        rotaion %= 360.0f;
        if(Mathf.Abs(rotaion) > 180.0f)
        {
            if (rotaion < 0.0f)
                rotaion += 360.0f;
            else
                rotaion -= 360.0f;
        }

        return rotaion;
    }
}
