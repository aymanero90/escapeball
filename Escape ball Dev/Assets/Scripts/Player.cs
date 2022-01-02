using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float MoveSpeed;
    [SerializeField] 
    private Collider collider;
    [SerializeField]
    private GameObject Fallscreen;
    [SerializeField]
    private Text score;

    private int collected = 0;

    Vector3 moveVector;

    private float xAxis;
    private float zAxis;
    private Rigidbody component;
    private bool isJumpPressed;

    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        Fallscreen.SetActive(false);
        component = GetComponent<Rigidbody>();
        distToGround = collider.bounds.extents.y;
        
    }

    // Update is called once per frame
    void Update()
    {        
        getInput();

        if (transform.position.y < -15f)
        {
            Fallscreen.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        movePlayer();

        if (isJumpPressed && IsGrounded())
        {          
            component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);          
            isJumpPressed = false;
        }       
    }

    private void getInput()
    {
        //Movement
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        moveVector = new Vector3(xAxis, 0f, zAxis);
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
            isJumpPressed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)  // coins Layer
        {
            Destroy(other.gameObject);
            SoundManager.instance.CoinSound();
            collected++;
            score.text = ""+ collected;
        }

        if (other.gameObject.layer == 8)  // Target Layer
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex == 3 ? 1 : currentSceneIndex + 1);            
        }
       
    }

    private void movePlayer()
    {
        component.AddForce(moveVector * MoveSpeed);        
    }

    private bool IsGrounded() {
   return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
 }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.layer == 9)
        {
            print("bridge");
            SoundManager.instance.BridgeSound();
        }
    }
}