using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Gravity")]
    public Transform groundCheck;
    public float speed=5f;
    public float mouseSentivity = 180f;
    public Transform cameraHolder;
    public Animator animator;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private Vector2 moveInput;
    private CharacterController characterController;
    private float verticalRotation;
    private bool isGrounded;
    private Vector3 velocity;
    private bool isWalking = false;
    private int isThinkingHash;
    private PlayerInput playerInput;
    private float cameraPitch;
    private Vector2 lookInput;
    
    

    private void Awake()
    {
        

        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    #region Update

    private void Start()
    {
        animator.GetComponent<Animator>();
        isThinkingHash = Animator.StringToHash("isThinking");
       
        
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity = Vector3.zero;
        }



        //moveInput = new Vector3(h, 0f, v);
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Debug.Log(moveInput);
        lookInput = playerInput.actions["Look"].ReadValue<Vector2>();
        Debug.Log(lookInput);
        /*if (moveInput != Vector2.zero && isWalking==false)
        {
            isWalking = true;
            animator.SetBool("isWalking",true);
            
        }
        else if(moveInput == Vector3.zero && isWalking == true)
        {
            isWalking = false;
            animator.SetBool("isWalking", false);
        }*/
        

        bool isThinking = animator.GetBool(isThinkingHash);
        bool ThinkPressed = Input.GetKey("1");

        if(!isThinking && ThinkPressed)
        {
            animator.SetBool(isThinkingHash, true);
        }
        if(isThinking && !ThinkPressed)
        {
            animator.SetBool(isThinkingHash, false);
        }
        
        
       
        Move();
        if (animator != null && playerInput.actions["Move"].phase == InputActionPhase.Waiting)
        {
            animator.SetBool("isWalking", false);
        }
        Look();
    }

    #endregion

    #region Movement

    private void Move()
    {
        if (animator != null && animator.GetBool("isWalking") == false)
        {
            animator.SetBool("isWalking", true);
        }
        //moveInput = moveInput.normalized * speed * Time.deltaTime;
        Vector3 movementDirection = moveInput * speed * Time.deltaTime;
        characterController.Move(transform.right*movementDirection.x + transform.forward*movementDirection.y);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    #endregion

    #region LookAround

    private void Look()
    {
        //transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSentivity*Time.deltaTime);
        //verticalRotation += Input.GetAxisRaw("Mouse Y") * mouseSentivity*Time.deltaTime;
        //verticalRotation = Mathf.Clamp(verticalRotation, -10f, 20f);
        //cameraHolder.transform.localEulerAngles = Vector3.left * verticalRotation;

        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -10f, 10f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, cameraTransform.localRotation.y, 0f);

        transform.Rotate(transform.up, lookInput.x);
    }

    #endregion

    #region AnimationFunctions

    public void Clap()
    {
        animator.SetTrigger("Clap");
    }

    

   

    

    #endregion
}
