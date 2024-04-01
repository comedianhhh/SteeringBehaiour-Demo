using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteeringBehaviour : SteeringBehaviourBase
{
    protected Vector3 desiredVelocity;

    public float RadiusOfCircle = 5.0f;
    public Vector3 center;
    public void Awake()
    {
        center = transform.parent.transform.position;
        target = RandomPointInCircle(center, RadiusOfCircle);
    }
    public override Vector3 CalculateForce()
    {
        //CheckMouseInput();
        if (steeringAgent.IsBot3&&(transform.position - center).magnitude >= RadiusOfCircle)
        {
            target = RandomPointInCircle(center, RadiusOfCircle);
            steeringAgent.EnableBehavior<ArriveSteeringBehaviour>();
            steeringAgent.DisableBehavior<WanderSteeringBahaviour>();
            Debug.Log("Target out of range, switching to ArriveSteeringBehaviour");
        }

        return CalculateSeekForce();
    }

    protected Vector3 CalculateSeekForce()
    {
        desiredVelocity = (target - transform.position).normalized;
        desiredVelocity = desiredVelocity * steeringAgent.maxSpeed;
        return (desiredVelocity - steeringAgent.velocity);
    }

    private Vector3 RandomPointInCircle(Vector3 origin, float radius)
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        return origin + new Vector3(randomPoint.x, 0, randomPoint.y);
    }

    protected virtual void OnDrawGizmos()
    {

        if(steeringAgent != null)
        {
            DebugExtension.DebugArrow(transform.position, desiredVelocity, Color.red);
            DebugExtension.DebugArrow(transform.position, steeringAgent.velocity, Color.blue);
        }
        DebugExtension.DebugCircle(center, Vector3.up, Color.grey, RadiusOfCircle);
        DebugExtension.DebugPoint(target, Color.magenta);
    }

}
