using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    private Rigidbody rB;
    public bool onGround;
    public float rotSpeed = 10.0f;
    private float timecount;
    public bool timeflag = true;

    public GameObject Goaltext;
    public TextMeshProUGUI Timetext;

    public float greattime;
    public float goodtime;
    public float normaltime;
    public float badtime;
    public TextMeshProUGUI scoretext;

    public GameObject audioManager;
    private AudioClips audioClips;
    private AudioClip goalSound;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        onGround = true;

        Goaltext.SetActive(false);

        audioManager = GameObject.Find("GameManager");
        audioClips = audioManager.GetComponent<AudioClips>();
        goalSound = audioClips.sound4;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeflag == true)
        {
            timecount += Time.deltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        float xPos = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zPos = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 moveDir = new Vector3(xPos, 0, zPos);
        this.transform.position += moveDir;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Goaltext.SetActive(true);
            timeflag = false;
            Timetext.text = timecount.ToString("F2");
            audioClips.audioSource.PlayOneShot(goalSound);

            if (timecount <= greattime)
            {
                scoretext.text = "‚ß‚Á‚¿‚á‚â‚é‚â‚ñ";
            }
            else if (timecount >= greattime&&timecount<=goodtime)
            {
                scoretext.text = "‚â‚é‚â‚ñ";
            }
            else if (timecount >= goodtime && timecount <= normaltime)
            {
                scoretext.text = "‚¢‚¢‚©‚ñ‚¶`";
            }
            else if (timecount >= normaltime && timecount <= badtime)
            {
                scoretext.text = "‚à‚¤‚¢‚Á‚Û‚Á‚Ä‚Æ‚±‚â‚È";
            }
            else if(timecount>=badtime)
            {
                scoretext.text = "‚Å‚È‚¨‚µ‚Ä‚«‚È";
            }
            Time.timeScale = 0;

        }
    }
}
