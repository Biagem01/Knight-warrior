using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float poweredSpeed;
    //private float currentSpeed;
    [SerializeField] private float normalJumpPower;
    [SerializeField] private float poweredJumpPower;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
     private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("Jump Sound")]
    [SerializeField] private AudioClip JumpSound;
    private AudioSource jumpAudioSource;

    private bool isOnBox = false;

    public bool wasd = true ;
     private bool temporaryWASD;  

    public ParticleSystem dustParticles;
    public SpeedTrailController speedTrailController;

    public delegate void SpeedPowerUpHandler(float poweredSpeed);
    public static event SpeedPowerUpHandler OnSpeedPowerUpCollected;


     





    private void Start()
    {
        speed = normalSpeed;
        jumpPower = normalJumpPower;
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        jumpAudioSource = gameObject.AddComponent<AudioSource>();
        jumpAudioSource.clip = JumpSound;
        jumpAudioSource.volume = 0.1f; 

       
    }


   


    private void Update()
    {
         Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(1, 1), 0);
    
     
      if (wasd)
      {
         horizontalInput = Input.GetAxis("Horizontal_WASD");
         //Debug.Log("Using WASD input: " + horizontalInput);
      }
      else
      {
       // horizontalInput = 0f;
         horizontalInput = Input.GetAxis("Horizontal_ArrowKeys");
         
        
        // Debug.Log("Using ArrowKeys input: " + horizontalInput);
      }   


        
       

    



        

        //Flip player when moving left-right
         if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(2, 2, 2);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2, 2, 2);

     
        
        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.G))
            {
                temporaryWASD = wasd;
                Jump();
                

                if(Input.GetKeyDown(KeyCode.G) && isGrounded())
                {
                    SoundManager.instance.PlaySound(JumpSound);
                }
            }    
        }
        else
            wallJumpCooldown += Time.deltaTime;

        if (Input.GetButtonDown("Jump") && (isOnBox || isGrounded()))
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PowerUp"))
            {
            // Il giocatore ha raccolto il power-up, attiva l'altezza del salto potenziato
                
                jumpPower = poweredJumpPower;
                Destroy(collider.gameObject); // Rimuovi il power-up dalla scena
            }
        }

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Speed"))
            {
                // Il giocatore ha raccolto il power-up, attiva la velocità e l'altezza del salto potenziato
                speed = poweredSpeed;
                //currentJumpPower = poweredJumpPower;

                if (OnSpeedPowerUpCollected != null)
                    OnSpeedPowerUpCollected(speed);

                Destroy(collider.gameObject); // Rimuovi il power-up dalla scena
                  
            }
        }

          if (dustParticles != null)
        {
            Vector3 dustPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            dustParticles.transform.position = dustPosition;
        }

        
       
    }

     private void HandleSpeedPowerUp(float poweredSpeed)
    {
        speed = poweredSpeed;
    }

    private void OnDestroy()
    {
        // Assicurati di annullare l'iscrizione all'evento quando lo script viene distrutto
        OnSpeedPowerUpCollected -= HandleSpeedPowerUp;
    }



private void Jump()
{
    if (isGrounded())
    {
        jumpAudioSource.Play();

        float jumpDirection = temporaryWASD ? horizontalInput : Mathf.Sign(transform.localScale.x);

        
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");

            if (dustParticles != null)
            {
                dustParticles.Play();
            }
        
    }
    else if (onWall() && !isGrounded())
    {
        if (horizontalInput == 0)
        {
            // Mantieni la direzione attuale del personaggio quando salta contro una parete
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, jumpPower);
        }
        else
        {
            // Mantieni la direzione attuale del personaggio quando salta contro una parete
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        

        }

        wallJumpCooldown = 0;
    }
}

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }


     public void SetOnBox(bool value)
    {
        isOnBox = value;
    }

    







}

   



   
