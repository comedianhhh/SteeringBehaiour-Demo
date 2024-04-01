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
        if(steeringAgent.IsBot3)
        {
            //if ((transform.position - center).magnitude >= RadiusOfCircle)
            //{
            //    target = RandomPointInCircle(center, RadiusOfCircle);
            //    if(steeringAgent.summingMethod ==SteeringAgent.SummingMethod.WeightedAverage)
            //    {
            //        foreach( var be in steeringAgent.steeringBehaviours)
            //        {
            //            if(be is WanderSteeringBahaviour)
            //            {
            //                be.weight = 10.0f;
            //            }
            //            else if(be is SeekSteeringBehaviour)
            //            {
            //                be.weight =20.0f ;
            //            }
            //        }
            //        steeringAgent.summingMethod=SteeringAgent.SummingMethod.Prioritized;
            //    }
            //}
            //else if(steeringAgent.summingMethod == SteeringAgent.SummingMethod.Prioritized && (transform.position - target).magnitude < 0.3f)
            //{
            //    steeringAgent.summingMethod =SteeringAgent.SummingMethod.WeightedAverage;

            //    foreach (var be in steeringAgent.steeringBehaviours)
            //    {
            //        if (be is WanderSteeringBahaviour)
            //        {
            //            be.weight = 20.0f;
            //        }
            //        else if (be is SeekSteeringBehaviour)
            //        {
            //            be.weight = 10.0f;
            //        }
            //    }
            //}
            if ((transform.position - center).magnitude >= RadiusOfCircle)
            {
                target = RandomPointInCircle(center, RadiusOfCircle);

                foreach (var be in steeringAgent.steeringBehaviours)
                {
                    if (be is WanderSteeringBahaviour)
                    {
                        be.weight = 1.0f;
                    }
                    else if (be is SeekSteeringBehaviour)
                    {
                        be.weight = 20.0f;
                    }
                }


            }
            else if ((transform.position - target).magnitude < 0.3f)
            {

                foreach (var be in steeringAgent.steeringBehaviours)
                {
                    if (be is WanderSteeringBahaviour)
                    {
                        be.weight = 20.0f;
                    }
                    else if (be is SeekSteeringBehaviour)
                    {
                        be.weight = 1.0f;
                    }
                }
            }
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
