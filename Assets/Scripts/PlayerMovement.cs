using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //#1 Player Movement
    public float jumpForce;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    //#2 Finding The Ground
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    //#3 player Animation
    private Animator myAnimator;
    //#9 better jump
    public float jumpTime;
    private float jumpTimeCounter;
    //#10 Speed Up
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    //#10 Better Ground Detection
    public Transform groundCheck;
    public float groundCheckRadious;
    //#11 Restarting
    public GameManager theGameManager;
    //#Reset Move Speed When Die
    private float moveSpeedStore;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody=GetComponent<Rigidbody2D>();
        //
        myCollider=GetComponent<Collider2D>();
        //
        myAnimator=GetComponent<Animator>();
        //
        jumpTimeCounter=jumpTime;
        //
        speedMilestoneCount=speedIncreaseMilestone;
        //
        speedIncreaseMilestoneStore=speedIncreaseMilestone;
        speedMilestoneCountStore=speedMilestoneCount;
        moveSpeedStore=moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //grounded=Physics2D.IsTouchingLayers(myCollider,whatIsGround);
        grounded=Physics2D.OverlapCircle(groundCheck.position,groundCheckRadious,whatIsGround);
        //
        if(transform.position.x>speedIncreaseMilestone)
        {
            speedMilestoneCount+=speedIncreaseMilestone;
            speedIncreaseMilestone=speedIncreaseMilestone*speedMultiplier;
            moveSpeed=moveSpeed*speedMultiplier;
        }
        //myRigidbody.velocity=new Vector3(moveSpeed,myRigidbody.velocity.y,0f);
        myRigidbody.velocity=new Vector2(moveSpeed,myRigidbody.velocity.y);
        if(Input.GetKeyDown(KeyCode.Z)||Input.GetMouseButtonDown(0))
        {
            //only jump when grounded
            if(grounded)//grounded=true
            {
                myRigidbody.velocity=new Vector2(myRigidbody.velocity.x,jumpForce);
                //myRigidbody.velocity=new Vector3(myRigidbody.velocity.x,jumpForce,0f);
            }
        }
        if(Input.GetKey(KeyCode.Z)||Input.GetMouseButton(0))
        {
            if(jumpTimeCounter>0)
            {
                myRigidbody.velocity=new Vector2(myRigidbody.velocity.x,jumpForce);
                jumpTimeCounter-=Time.deltaTime;
            }
        }
        /*if(Input.GetKeyUp(KeyCode.Z)||Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter=0;
        }*/
        if(grounded)
        {
            jumpTimeCounter=jumpTime;
        }
        myAnimator.SetFloat("Speed",myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded",grounded);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="KillBox")
        {
            
            theGameManager.RestartGame();
            moveSpeed=moveSpeedStore;
            speedMilestoneCount=speedMilestoneCountStore;
            speedIncreaseMilestone=speedIncreaseMilestoneStore;
        }
    }
}
