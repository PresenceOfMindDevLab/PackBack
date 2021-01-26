using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool alreadyPlayed = false;
    public Animator animator;
    public Rigidbody2D rb;
    public Rigidbody2D rotationRB;
    public Camera camera;
    public GameObject fullinventory;

    public float moveSpeed;
    Vector2 movement;
    Vector2 mousePosition;

    private bool isMoving;
    public bool lookLeft = false;

    private bool inventoryOpen;

    //shooting
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    public float projectileForce;

    private void Start()
    {
        
    }

    void Update()
    {

        

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        inventoryOpen = fullinventory.GetComponent<triggerinv>().inventoryOpen;
        //left click for shooting; only shoot if not moving and inventory is not open
        if (Input.GetButtonDown("Fire1") && isMoving == false && inventoryOpen == false)
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement != Vector2.zero)
        {
            
            //FindObjectOfType<AudioManager>().Play("MageSteps");

            Move();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if(movement.x > 0 || movement.y < 0)
            {
                lookLeft = false;
            } else {
                lookLeft = true; 
            }
            animator.SetBool("moving", true);
            isMoving = true;
        } else {
            animator.SetBool("moving", false);
            isMoving = false;
        }
       
        //rotation following mouse
        if(isMoving == false)
        {
            Vector2 lookDirection = mousePosition - rotationRB.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rotationRB.rotation = angle;
        }

    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingPoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
