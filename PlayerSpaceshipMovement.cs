using UnityEngine;

public class PlayerSpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private float currentMoveSpeed;

    [SerializeField]
    private float maxMoveSpeed;

    [SerializeField]
    private float verticalMovementAxis;

    [SerializeField]
    private float turnSpeed;

    private float VerticalMovementAxis
    {
        get
        {
            if(verticalMovementAxis > 1)
            {
                verticalMovementAxis = 1;
            }
            if(verticalMovementAxis < -1)
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }

            if(Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


        YMovementInput();

        Move();

        if(Input.GetAxisRaw("Mouse X") > 0)
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetAxisRaw("Mouse X") < 0)
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetAxisRaw("Mouse Y") > 0)
        {
            transform.Rotate(turnSpeed * Time.deltaTime, 0, 0);
        } 

        if(Input.GetAxisRaw("Mouse Y") < 0)
        {
            transform.Rotate(-turnSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void YMovementInput ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            VerticalMovementAxis += 1;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            VerticalMovementAxis -= 1;
        }
        else if(!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftControl))
        {
            VerticalMovementAxis = 0;
        }
    }

    private void Move()
    {
        transform.Translate(MovementVector() * Time.deltaTime);
    }

    private Vector3 MovementVector ()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), VerticalMovementAxis, Input.GetAxisRaw("Vertical")) * currentMoveSpeed;
    }
}