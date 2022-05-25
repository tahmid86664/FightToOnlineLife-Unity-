using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{
    //public
    public float moveSpeed = 0f;
    public float jumpForce = 0f;
    public float gravity = 9.8f;

    //private
    private CharacterController myCharacterController;
    private float verticalVelocity;

    void Start()
    {
        //Debug.Log(GameManager.gender);
        myCharacterController = this.gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (myCharacterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
            
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;

        Vector3 moveVertical = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;
        Vector3 moveHorizontal = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
        Vector3 moveAlongY = new Vector3(0, verticalVelocity * Time.deltaTime, 0);

        Vector3 movement = transform.TransformDirection(moveVertical + moveHorizontal + moveAlongY);


        myCharacterController.Move(movement);
    }
}
