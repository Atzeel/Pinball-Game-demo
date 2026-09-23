using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperController : MonoBehaviour
{
    public bool isLeftFlipper = true;

    public float flipAngle = 45f;
    public float speed = 700f;

    private Rigidbody2D rb;
    private float restAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        restAngle = rb.rotation;
    }

    void FixedUpdate()
    {
        bool pressed = false;

        if (Keyboard.current != null)
        {
            if (isLeftFlipper)
            {
                pressed = Keyboard.current.leftArrowKey.isPressed;
            }
            else
            {
                pressed = Keyboard.current.rightArrowKey.isPressed;
            }
        }

        float targetAngle = restAngle;

        if (pressed)
        {
            if (isLeftFlipper)
                targetAngle = restAngle + flipAngle;
            else
                targetAngle = restAngle - flipAngle;
        }

        float newAngle = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, speed * Time.fixedDeltaTime
        );

        rb.MoveRotation(newAngle);
    }
}