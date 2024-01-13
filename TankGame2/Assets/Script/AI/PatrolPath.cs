using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    //Tạo một List để lưu các điểm patrolPoints mà ta đã đánh dấu ở trên map
    public List<Transform> patrolPoints = new List<Transform>();

    //Lấy ra số patrolPoints của List trên
    public int Length { get => patrolPoints.Count; }

    //Tại đây chúng ta set các đặc tính hiển thị của các điểm cũng như line của patrolPaths đi trên màn hình
    [Header("Gizmos parameters")]
    public Color pointsColor = Color.blue;
    public float pointSize = 0.3f;
    public Color lineColor = Color.magenta;

    //Tạo một struct tên là PathPoint để lưu một chỉ số Index và một tọa độ 2D
    //Mục đích là lưu vị trí của patrol Point và chỉ số index của patrol Point đó 
    public struct PathPoint
    {
        public int Index;
        public Vector2 Position;
    }

    //Tạo ra một hàm để lấy ra điểm gần nhất trên Patrol - Truyền vào là một tọa độ 2D (Vị trí của tank)
    public PathPoint GetClosestPathPoint(Vector2 tankPosition)
    {
        //Tạo ra biến minDistance 
        var minDistance = float.MaxValue;
        //Khởi tạo chỉ số index = -1
        var index = -1;
        //Duyệt qua các điểm trong patrolPath
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            //Tạo ra một biến tempDistance để ta có thể lấy ra khoảng cách từ vị trí tank đến các vị trí của patrolPoint
            var tempDistance = Vector2.Distance(tankPosition, patrolPoints[i].position);
            //Ta kiểm tra xem khoảng cách đó có nhỏ hơn minDistance không
            if (tempDistance < minDistance)
            {
                //Nếu có thì gán minDistance = khoảng cách hiện tại
                minDistance = tempDistance;
                //Chỉ số index là chỉ số của patrol point mà ta đang xét
                index = i;
            }
        }

        //Trả về PathPoint lưu chỉ số index cũng như vị trí của patrolPoint đó 
        return new PathPoint { Index = index, Position = patrolPoints[index].position };
    }

    //Hàm này đế lấy ra vị trí và chỉ số index của patrol Point tiếp theo
    public PathPoint GetNextPathPoint(int index)
    {
        //Kiểm tra xem là chỉ số index đó có vượt qua số lượng patrol Point chưa 
        //Nếu chưa thì tăng index lên 1 còn nếu rồi thì trở về vị trí 0
        //Như vậy là ta tạo ra một chu trình
        var newIndex = index + 1 >= patrolPoints.Count ? 0 : index + 1;
        return new PathPoint { Index = newIndex, Position = patrolPoints[newIndex].position };
    }


    private void OnDrawGizmos()
    {
        if (patrolPoints.Count == 0)
            return;
        for (int i = patrolPoints.Count - 1; i >= 0; i--)
        {
            if (i == -1 || patrolPoints[i] == null)
                return;

            Gizmos.color = pointsColor;
            Gizmos.DrawSphere(patrolPoints[i].position, pointSize);

            if (patrolPoints.Count == 1 || i == 0)
                return;

            Gizmos.color = lineColor;
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i - 1].position);

            if (patrolPoints.Count > 2 && i == patrolPoints.Count - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
            }
        }
    }
}
