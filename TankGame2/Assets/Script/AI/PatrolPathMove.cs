using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPathMove : MonoBehaviour
{
    public PatrolPath patrolPath;
    public float moveSpeed = 2f;
    public float arriveDistance = 0.1f;

    private PatrolPath.PathPoint currentTarget;

    void Start()
    {
        SetNextTarget();
    }

    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (patrolPath == null || patrolPath.Length == 0)
        {
            Debug.LogWarning("Patrol Path is not set or has no points.");
            return;
        }

        // Di chuyển đến điểm tiếp theo trên đường tuần tiện
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.Position, moveSpeed * Time.deltaTime);

        // Kiểm tra xem đã đến gần điểm đích chưa
        if (Vector2.Distance(transform.position, currentTarget.Position) < arriveDistance)
        {
            SetNextTarget();
        }
    }

    void SetNextTarget()
    {
        // Lấy điểm tiếp theo trên đường tuần tiện
        currentTarget = patrolPath.GetNextPathPoint(currentTarget.Index);

        // Đặt hướng di chuyển mới
        Vector2 directionToGo = currentTarget.Position - (Vector2)transform.position;
        float angle = Mathf.Atan2(directionToGo.y, directionToGo.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
