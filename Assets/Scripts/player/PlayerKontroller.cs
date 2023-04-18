using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerKontroller : MonoBehaviour
{
    private float movementDirection;
    public float speed;
    public float jumpPower;
    public float groundCheckRadius;
    public float attackRate = 2f;
    float nextAttack = 0;

    public AudioSource swordAS;


    private bool isFacingRight = true;
    private bool isGrounded;

    public LayerMask groundLayer;

    Rigidbody2D rb;
    Animator anim;

    public GameObject groundCheck;

    public Transform attackPoint;
    public float attackDistance;
    public LayerMask enemyLayers;
    public float damage;

    public GameObject ninjaStar;
    public Transform firePoint;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
        Jump();
        CheckSurface();
        CheckAnimations();
        
        if (Time.time > nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }

        Shoot();
       
    }
    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        movementDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementDirection * speed, rb.velocity.y);
        anim.SetFloat("runSpeed", Mathf.Abs (movementDirection * speed));
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (StarBank.instance.bankStar > 0)
            {
                Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                StarBank.instance.bankStar -= 1;
            }
        }
    }

    void CheckAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);

    }

    void CheckSurface()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
    }

    void CheckRotation() 
    {
        if (isFacingRight && movementDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementDirection > 0)
        {
            Flip();
        }

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }
       
    }

    public void Attack()
    {
        float numb = Random.Range(0, 2);

        if(numb == 0)
        {
            anim.SetTrigger("Attack1");
            AudioManager.instance.PlayAudio(swordAS);
        }
        else if(numb == 1)
        {
            anim.SetTrigger("Attack2");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDistance, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
             enemy.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
        Gizmos.DrawWireSphere(attackPoint.position, attackDistance);
    }
}
