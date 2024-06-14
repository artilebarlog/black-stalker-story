using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlerIgroka : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;//пешеход
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] GameObject shotgun;
    bool isGrounded = true;
    protected GameObject player;
    float currentSpeed;
    float stamina = 5f;
    int health = 100;
    Rigidbody rb;
    Vector3 direction;
    bool isShotgun;
    // Start is called before the first frame update
    public enum Weapons
    {
        None,
        Shotgun
    }
    Weapons weapons = Weapons.None;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (direction.x != 0 || direction.z != 0)
        {

        }
        if (direction.x == 0 && direction.z == 0)
        {

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = shiftSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = movementSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
        }
        if (stamina > 5f)
        {
            stamina = 5f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }
    }
    void FixedUpdate()
    {
        // rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
        rb.AddForce(direction*currentSpeed,ForceMode.Force);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    public void ChooseWeapon(Weapons weapons)
    {
        shotgun.SetActive(weapons == Weapons.Shotgun);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "shotgun":
                if (!isShotgun)
                {
                    isShotgun = true;
                    ChooseWeapon(Weapons.Shotgun);
                }
                break;
            default:
                break;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
//запомни вепон у тебя с маленькой буквы поэтому будет  (вепон вепон) ну если это будет работать.