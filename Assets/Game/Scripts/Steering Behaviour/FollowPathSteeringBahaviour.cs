using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPathSteeringBahaviour : ArriveSteeringBehaviour
{
    private float waypointDistance = 0.5f;
    private int currentWaypointIndex = 0;
    private NavMeshPath path;

    public int currentPointsIndex = 0;
    public List<Transform>points;
    public float pathPointDistance = 1.0f;

    public bool useNavMesh = true;
    private void Start()
    {
        path=new NavMeshPath();

    }
    public override Vector3 CalculateForce()
    {
        if (points.Count == 0) return Vector3.zero;

        // Decide which method to use based on the useNavMesh flag
        return useNavMesh ? CalculateNavMeshForce() : CalculateDirectForce();
    }

    private Vector3 CalculateDirectForce()
    {
        target = points[currentPointsIndex].position;

        if ((target - transform.position).magnitude < pathPointDistance)
        {
            currentPointsIndex++;
            if (currentPointsIndex >= points.Count)
            {
                currentPointsIndex = 0; // Optionally reset to loop or handle end of path differently
            }
        }

        return CalculateArriveForce();
    }

    private Vector3 CalculateNavMeshForce()
    {
        target = points[currentPointsIndex].position;

        if ((target - transform.position).magnitude < pathPointDistance)
        {
            currentPointsIndex++;
            if (currentPointsIndex >= points.Count)
            {
                currentPointsIndex = 0;
            }
        }

        currentWaypointIndex = 0;
        NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
        if (path.corners.Length > 0)
        {
            target = path.corners[0];
        }
        else
        {
            target = transform.position;
        }


        if (currentWaypointIndex != path.corners.Length && (target - transform.position).magnitude < waypointDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex < path.corners.Length)
            {
                target = path.corners[currentWaypointIndex];
            }
        }

        return CalculateArriveForce();
    }

    protected override void OnDrawGizmos()
    {
        //base.OnDrawGizmos();
        DebugExtension.DrawCircle(target, Color.magenta, waypointDistance);
        if (path!=null)
        {
            for(int i =1;i<path.corners.Length;i++)
            {
                Debug.DrawLine(path.corners[i-1], path.corners[i], Color.black);
            }
        }
    }
}
