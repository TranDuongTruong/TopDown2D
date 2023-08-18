using UnityEngine;

public class InputController : MonoBehaviour
{
    private static InputController instance;
    public static InputController Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    public Vector2 move;


    private void Update()
    {
        // B?t s? ki?n t? bàn phím
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        // B?t s? ki?n t? chu?t
        if (Input.GetMouseButtonDown(0))
        {
            OnFire();
        }
    }

    public Vector2 Move()
    {
        return move;
    }

    private void OnFire()
    {
        // X? lý s? ki?n khi nh?n chu?t
        
    }
}