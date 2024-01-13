using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTankControler : MonoBehaviour
{
    //Tạo ra để gắn Rigidbody2D trong Unity
    public Rigidbody2D rb2d;
    //Tạo ra để ta có thể gán giá trị movementData vào
    public TankMovementData movementData;
    //Nếu có nhiều Turret thì dùng cái này để gán nó vào
    public Turret[] turrets;

    //Tạo một Vector2 tên là movementVector
    private Vector2 movementVector;

    //Đối với hàm Update (Vòng lặp vô tận) - Ta cho hàm AutoShoot để nó có thể tự động bắn
    private void Update()
    {
        //Gọi hàm tự động bắn ở đây
        AutoShoot();
    }

    //Giờ thì đến với hàm AutoShoot
    private void AutoShoot()
    {
        //Lặp qua các turret ở trong list turret trên 
        foreach (var turret in turrets)
        {
            //Gọi hàm turret.Shoot để bắn
            turret.Shoot();
            //Thông báo cho biết là đang bắn 
            Debug.Log("TankController - Auto Shoot");
        }
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMove(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.right * movementVector.y * movementData.maxSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));

    }
}

