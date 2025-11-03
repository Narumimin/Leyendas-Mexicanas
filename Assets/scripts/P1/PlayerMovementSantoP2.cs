using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.Mathematics;

public class PlayerMovementSantoP2 : MonoBehaviour
{
    [Header("Movement attributes")]
    public float velocity = 5f; //Velocidad del jugador
    private Vector2 movement; //Vector para saber la direccion del movimiento del jugador
    private Rigidbody2D rb; //Rigidbody
    [SerializeField] private Collider2D standingCollider;
    [SerializeField] private Collider2D crouchingCollder;
    public bool isCrouching = false;
    public bool isAttacking = false;

    [Header("Jump attributes")]
    public float jumpVel; //Velocidad del salto
    public float jumpHeight = 5f;
    public float timeToJumpApex = 0.5f;
    private bool isJumping = false;
    [SerializeField] private float gravity;
    [SerializeField] private float gravityChange = 1f;
    private float coyoteTime = 0.1f; //Tiempo que queremos que dure el coyote time
    private float coyoteTimeCounter; //Contador con el que checamos el coyote time

    [Header("Animator")]
    public Animator animator; //Animator

    [Header("Grounded Info")]
    public LayerMask GroundLayer; //Detectar objetos con cierta layer puesta
    public Transform groundCheckPoint; //Punto donde se dibuja la esfera para checar si el jugador esta en el suelo
    public float radius; //Radio de la esfera mencionada

    [Header("Other player")]
    private GameObject otherPlayer;

    [Header("Sound")]
    private SonidosSanto sounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sounds = GetComponent<SonidosSanto>();
        gravity = (2 * jumpHeight) / math.pow(timeToJumpApex, 2);
        jumpVel = math.abs(gravity) * timeToJumpApex;
        rb.gravityScale = gravity;
        otherPlayer = GameObject.FindGameObjectWithTag("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        rb.WakeUp();

        if (Input.GetKeyUp(KeyCode.DownArrow) && isGrounded())
        {
            Uncrouch();
        }

        animator.SetBool("Crouching", isCrouching);
        if (isCrouching)
        {
            return;
        }

        if (isAttacking)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("HorizontalP2"); // recibir input de derecha o izquierda

        if (otherPlayer.transform.position.x <= transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (otherPlayer.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetBool("onFloor", isGrounded());
        //animator.SetFloat("movement", movement.x);

        if (isGrounded()) //Coyote time related stuff
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) && coyoteTimeCounter > 0f && !isJumping) //jump action
        {
            sounds.jump();
            Jump();
            coyoteTimeCounter = 0f;
            StartCoroutine(JumpCooldown());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded())
        {
            Crouch();
        }
    }

    private void FixedUpdate()
    {
        if (isCrouching)
        {
            return;
        }
        if (isAttacking)
        {
            return;
        }
        transform.Translate(movement * velocity * Time.deltaTime); //mover el jugador de derecha a izquierda
    }

    private bool isGrounded() // funcion para checar si el jugador esta en el piso
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, radius, GroundLayer);
    }

    private void Jump() // funcion para saltaar
    {
        rb.linearVelocityY = jumpVel;
        //rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVel);
        animator.SetBool("onFloor", false);
    }

    private IEnumerator JumpCooldown() //cooldown para el salto
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }

    private void Crouch()
    {
        isCrouching = true;
        standingCollider.enabled = false;
        crouchingCollder.enabled = true;
    }

    private void Uncrouch()
    {
        isCrouching = false;
        standingCollider.enabled = true;
        crouchingCollder.enabled = false;
    }

    private void OnDrawGizmos() // gizmo para checar el circulo que se usa en la funcion isGrounded
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheckPoint.position, radius);
    }
}
