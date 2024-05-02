using UnityEngine;

public class Wizard : MonoBehaviour
{
    public static Wizard Instance; // Singletone variable
    public GameObject fireballPrefab; 
    private float lastFireTime = 0; 
    private Vector3 lastMovement;
    private Animator animator;
    public Playerstats Stats;
    
    void Start()
    {
        Stats  = new Playerstats();
        Instance = this; // Singleton instance erzeugen auf diesem Objekt.
        lastFireTime = -Stats.fireRate; 
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 movement = Vector3.zero;
 
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }
 
        if (movement.magnitude > 0.01f)
        {
            movement = movement.normalized;
            lastMovement = movement;
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }
 
        transform.position += movement * Stats.movementspeed * Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastFireTime >= Stats.fireRate)
        {
            
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Feuerball>().direction = lastMovement;
            lastFireTime = Time.time; 
            animator.SetBool("Attacking", true);
            Stats.mana -= 10;
        }
        if(Stats.mana < Stats.MaxMana)
        {
            Stats.mana += Stats.manaRegen;
        } else {
            Stats.mana = Stats.MaxMana;
        }

    }
    public void stopAttacking(){
        animator.SetBool("Attacking", false);
    }
}