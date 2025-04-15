using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed;
    private Vector3 movementInput;
    private bool isDead = false;
    public GameObject playerMeshObject;
    private Vector3 startPosition;
    public GameObject cameraObject;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    public float woodcounter = 0;
    public TextMeshProUGUI woodd;
    public float stonecounter = 0;
    public TextMeshProUGUI stone;
    private mainislandquests quest;


    public GameObject deathpanel;
    // Start is called before the first frame update
    void Start()
    {
        quest = FindObjectOfType<mainislandquests>();
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            getMovementInput();
            moveCamera();
        }
        woodd.text = woodcounter.ToString("0");
        stone.text = stonecounter.ToString("0");

        quest.ChekQuestProcessing(woodcounter, stonecounter);

    }



    private void FixedUpdate()
    {
        movePlayer();
    }
    void getMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movementInput = new Vector3(-horizontal, 0, -vertical);
    }

    private void movePlayer()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movementInput * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "water")
        {
            Death();
        }
    }


    private void Death()
    {
        isDead = true;
        playerMeshObject.SetActive(false);
        deathpanel.SetActive(true);

        Invoke("Respawn", 3);
    }

   

   

    private void Respawn()
    {
        transform.position = startPosition;
        playerMeshObject.SetActive(true);
        isDead = false;
        deathpanel.SetActive(false);
    }

    void moveCamera()
    {
        cameraObject.transform.position = new Vector3(transform.position.x,
            transform.position.y + cameraOffsetY,
            transform.position.z + cameraOffsetZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wood")
        {
            woodcounter++;
            Destroy(other.gameObject);
        }
        if (other.tag == "stone")
        {
            stonecounter++;
            Destroy(other.gameObject);
        }
    }


}

