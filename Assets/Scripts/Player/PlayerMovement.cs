using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float sprintSpeed;

    [SerializeField] private Rigidbody2D Rigidbody2D;

    private float CurrentSpeed
    {
        get 
        {
            if (isSprinting)
                currentSpeed = sprintSpeed;
            else
                currentSpeed = moveSpeed;

            return currentSpeed;
        }
    }
    public void ChangeMoveSpeed(float newSpeed) => moveSpeed = newSpeed;
    public void ChangeSprintSpeed(float newSprintSpeed) => sprintSpeed = newSprintSpeed;


    private Vector2 dir;
    private float hor;
    private float ver;

    [SerializeField] private bool isSprinting;

    public void UpdateMovement()
    {
        GetInput();
        Move();
    }
    public void FixedUpdateMovement()
    {
        MoveWithRigidbody();
    }
    private void MoveWithRigidbody()
    {
        //if(Rigidbody2D.linearVelocity.magnitude < 10)
        //{
        //    Rigidbody2D.AddForce(dir * CurrentSpeed);
        //}
    }
    private void GetInput()
    {
        MoveInput();
        SprintInput();
    }
    
    private void MoveInput()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        dir = new Vector2(hor, ver);
        dir.Normalize();
    }
    private void SprintInput()
    {
       isSprinting = Input.GetKey(KeyCode.LeftShift);
    }
    private void Move()
    {
        transform.position += (Vector3)(dir * CurrentSpeed * Time.deltaTime);
    }
}
