using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollaboratorAgent : MonoBehaviour
{
    public Transform[] points;
    public GameObject targetparticle;
    private int desPoint = 0;
    private NavMeshAgent agent;


    public GameObject audioManager;
    private AudioClips audioClips;
    private AudioClip robotSound;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Rotate(-90.0f, 0f, 0f);
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        audioManager = GameObject.Find("GameManager");
        audioClips = audioManager.GetComponent<AudioClips>();
        robotSound = audioClips.sound5;

        GotoNextPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

    }

    void GotoNextPoint()
    {
        

        if (points.Length == 0)
        {
            return;
        }

        Vector3 pos = targetparticle.transform.position;
        pos = points[desPoint].position;
        targetparticle.transform.position = pos;
   
        agent.destination = points[desPoint].position;
        desPoint = (desPoint + 1) % points.Length;
        Debug.Log(desPoint);

        audioClips.audioSource.PlayOneShot(robotSound);

    }
}
