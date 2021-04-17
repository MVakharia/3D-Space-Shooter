using UnityEngine;

public class PlayerSpaceshipMovement : MonoBehaviour
{
    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float verticalMovementAxis;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    [SerializeField] private float xMoveSpeed;
    private float XMoveSpeed
    {
        get
        {
            if (xMoveSpeed > maxMoveSpeed)
            {
                xMoveSpeed = maxMoveSpeed;
            }
            if (xMoveSpeed < -maxMoveSpeed)
            {
                xMoveSpeed = -maxMoveSpeed;
            }
            return xMoveSpeed;
        }
        set
        {
            xMoveSpeed = value;
        }
    }

    [SerializeField] private float yMoveSpeed;

    private float YMoveSpeed
    {
        get
        {
            if (yMoveSpeed > maxMoveSpeed)
            {
                yMoveSpeed = maxMoveSpeed;
            }
            if (yMoveSpeed < -maxMoveSpeed)
            {
                yMoveSpeed = -maxMoveSpeed;
            }
            return yMoveSpeed;
        }
        set
        {
            yMoveSpeed = value;
        }
    }

    [SerializeField] private float zMoveSpeed;

    private float ZMoveSpeed
    {
        get
        {
            if (zMoveSpeed > maxMoveSpeed)
            {
                zMoveSpeed = maxMoveSpeed;
            }
            if (zMoveSpeed < -maxMoveSpeed)
            {
                zMoveSpeed = -maxMoveSpeed;
            }
            return zMoveSpeed;
        }
        set
        {
            zMoveSpeed = value;
        }
    }

    private float VerticalMovementAxis
    {
        get
        {
            if (verticalMovementAxis > 1)
            {
                verticalMovementAxis = 1;
            }
            if (verticalMovementAxis < -1)
            {
                verticalMovementAxis = -1;
            }
            return verticalMovementAxis;
        }
        set
        {
            verticalMovementAxis = value;
        }
    }

    private void ToggleLockCursor ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void MouseLook() => transform.Rotate(turnSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse Y"), turnSpeed * Time.deltaTime * Input.GetAxisRaw("Mouse X"), 0);

    private void Update()
    {
        ToggleLockCursor();

        YMovementInput();

        Move();

        MouseLook();

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            if(XMoveSpeed > 0)
            {
                XMoveSpeed -= deceleration * Time.deltaTime;
            }

            if(XMoveSpeed < 0)
            {
                XMoveSpeed += deceleration * Time.deltaTime;
            }

            if(XMoveSpeed < 0.1F && XMoveSpeed > -0.1F)
            {
                XMoveSpeed = 0;
            }
        }

        XMoveSpeed += Input.GetAxisRaw("Horizontal") * acceleration * Time.deltaTime;

        if (VerticalMovementAxis == 0)
        {
            if (YMoveSpeed > 0)
            {
                YMoveSpeed -= deceleration * Time.deltaTime;
            }

            if (YMoveSpeed < 0)
            {
                YMoveSpeed += deceleration * Time.deltaTime;
            }

            if (YMoveSpeed < 0.1F && YMoveSpeed > -0.1F)
            {
                YMoveSpeed = 0;
            }
        }

        YMoveSpeed += VerticalMovementAxis * acceleration * Time.deltaTime;

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (ZMoveSpeed > 0)
            {
                ZMoveSpeed -= deceleration * Time.deltaTime;
            }

            if (ZMoveSpeed < 0)
            {
                ZMoveSpeed += deceleration * Time.deltaTime;
            }

            if (ZMoveSpeed < 0.1F && ZMoveSpeed > -0.1F)
            {
                ZMoveSpeed = 0;
            }
        }

        ZMoveSpeed += Input.GetAxisRaw("Vertical") * acceleration * Time.deltaTime;
    }

    private void YMovementInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            VerticalMovementAxis += 1;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            VerticalMovementAxis -= 1;
        }
        else if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftControl))
        {
            VerticalMovementAxis = 0;
        }
    }

    private void Move()
    {
        transform.Translate(MovementVector() * Time.deltaTime);
    }

    private Vector3 MovementVector()
    {
        return new Vector3(XMoveSpeed, YMoveSpeed, ZMoveSpeed);
    }


}