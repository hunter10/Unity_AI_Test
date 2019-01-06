using System.Collections;
using UnityEngine;

public class Face : Align {
    protected GameObject targetAux;

    public override void Awake()
    {
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    private void OnDestroy()
    {
        Destroy(target);
    }

    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        if(direction.magnitude > 0.0f)
        {
            float targetOrientaion = Mathf.Atan2(direction.x, direction.z);
            targetOrientaion *= Mathf.Rad2Deg;
            target.GetComponent<Agent>().orientation = targetOrientaion;
        }
        return base.GetSteering();
    }
}
