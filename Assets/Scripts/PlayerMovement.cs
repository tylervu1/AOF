using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    bool isGrounded;


    [Header("Shooting")]
    public float bullet_speed;
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    [Header("Health")]
    public float health, max_health = 10f;
    public HealthBar healthBar;

    [Header("Sounds")]
    public AudioSource player_hit_sound;
    public AudioSource shuriken_sound;

    [Header("Other")]
    public Transform orientation;
    
    float horizontalInput;
    float verticalInput;

    public GameControl game;
    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
        health = max_health;
        healthBar.setMaxHealth(max_health);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        MyInput();
        SpeedControl();
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && canJump && isGrounded)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }

    private void Shoot()
    {
        shuriken_sound.Play();   
        GameObject bulletObj = Instantiate(bullet, bulletSpawnPoint.position, orientation.rotation) as GameObject;
        Rigidbody bullet1 = bulletObj.GetComponent<Rigidbody>();

        bullet1.transform.rotation = orientation.rotation;
        bullet1.AddForce(bullet1.transform.forward * bullet_speed);
        Destroy(bulletObj, 3f);
    }

    public void TakeDamage(float damage)
    {
        player_hit_sound.Play();
        health -= damage;
        healthBar.setHealth(health);
        if (health <= 0)
        {
            game.EndGame();
        }

    }
}
