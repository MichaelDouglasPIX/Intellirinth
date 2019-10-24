using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float vel = 0f;
    [SerializeField] float jumpFprce;
    float movement;
    Animator anim;
    float rotacionar = 100;
    private Vector3 pos;
    Rigidbody rb;
    bool paused;

    public bool vJump;
    public GameObject menuPause;
    public GameObject displayContagem;
    private float timeExtra;
    public GameObject spawnLabirinto;

    // Start is called before the first frame update
    private void Awake()
    {
        spawnLabirinto = GameObject.Find("Spawn");
        displayContagem = GameObject.Find("UI");
        menuPause = GameObject.Find("Pause");
        

    }

    void Start()
    {
        menuPause.gameObject.SetActive(false);
        timeExtra = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {/*

        movement = Input.GetAxis("Vertical") * Time.deltaTime * vel;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement += 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movement = 1;
        }

        anim.SetFloat("Walk", movement);

        this.transform.Rotate(0, (Input.GetAxis("Horizontal") * rotacionar)* Time.deltaTime, 0);

        rb.transform.Translate(0, 0, movement);
        */
        if (paused == false)
        {
            if (vJump)
            {

                float z = Input.GetAxis("Vertical") * Time.deltaTime * vel;
                rb.transform.Translate(0, 0, z);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (vel <= 3)
                    {
                        vel += 0.05f;
                    }
                    else
                    {
                        vel = 3f;
                    }

                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    vel = 1f;
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(transform.up * jumpFprce);
                }
            }
            this.transform.Rotate(0, (Input.GetAxis("Horizontal") * rotacionar) * Time.deltaTime, 0);

            if (Input.GetKey(KeyCode.LeftAlt))
            {

                spawnLabirinto.GetComponent<Labirinto>().GerandoLabirinto();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                menuPause.gameObject.SetActive(true);
                displayContagem.GetComponent<Countdown>().contagemStart = false;
                paused = true;
            }
            else
            {
                menuPause.gameObject.SetActive(false);
                displayContagem.GetComponent<Countdown>().contagemStart = true;
                paused = false;
            }

        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
       vJump= collision.contacts[0].point.y < transform.position.y;
    }

    private void OnCollisionExit(Collision collision)
    {
        vJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Time")
        {
            other.gameObject.SetActive(false);
            timeExtra = 5.10f + displayContagem.GetComponent<Countdown>().contagem;
            displayContagem.GetComponent<Countdown>().contagem = timeExtra;
            print(timeExtra);

        }
        
    }

}
