using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed;
    [SerializeField] private float moveSpeed;
    //[SerializeField] private float sprintSpeed;
    [SerializeField] private Rigidbody2D Rigidbody2D;


    [SerializeField] private bool canSprint;
    [SerializeField] private bool canDash;
    [SerializeField] private bool canDodge;

    public bool CanSprint
    {
        get => canSprint;
        set => canSprint = value;
    }
    public bool CanDash
    {
        get => canDash;
        set => canDash = value;
    }
    public bool CanDodge
    {
        get => canDodge;
        set => canDodge = value;
    }



    private float CurrentSpeed
    {
        get 
        {
            if (isSprinting && canSprint)
                currentSpeed = /*sprintSpeed*/ moveSpeed + 10;
            else
                currentSpeed = moveSpeed;

            return currentSpeed;
        }
    }
    public void ChangeMoveSpeed(float newSpeed) => moveSpeed = newSpeed;
    //public void ChangeSprintSpeed(float newSprintSpeed) => sprintSpeed = newSprintSpeed;


    private Vector2 direction;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private bool isSprinting;

    public void UpdateMovement()
    {
        GetInput();
        Move();
    }
   
    private void GetInput()
    {
        MoveInput();
        SprintInput();
    }
    
    private void MoveInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontalInput, verticalInput);
        direction.Normalize();
    }
    private void SprintInput()
    {
       isSprinting = Input.GetKey(KeyCode.LeftShift);
    }
    private void Move()
    {
        transform.position += (Vector3)(direction * CurrentSpeed * Time.deltaTime);
    }
    public void PlayerMovement_OnValuesChanged(Dictionary<string, PlayerStat> stats)
    {
        canDash = stats["Dash"].boolData;
        canDodge = stats["Dodge"].boolData;
        canSprint = stats["Sprint"].boolData;
        moveSpeed = stats["Speed"].floatData;
        //   stats["speed"]
        Debug.Log(stats["Speed"].floatData);
    }
}
