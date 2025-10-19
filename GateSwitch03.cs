using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch02 : MonoBehaviour
{

    public GameObject Gate;
    public int count = 0;
    private bool switch01;
    private bool switch02;
    public int countanswer = 0;

    //サウンド系
    public GameObject audioManager;
    private AudioClips audioClips;
    private AudioClip onswitchSound;
    private AudioClip offswitchSound;
    private AudioClip gateopenSound;
    [SerializeField]private bool playOneShotFlag=false;
    private bool flagCache=false;

    //アニメーター系
    private Animator anim = null;


    // Start is called before the first frame update
    void Start()
    {
        switch01 = false;

        //サウンド系
        audioManager = GameObject.Find("GameManager");
        audioClips = audioManager.GetComponent<AudioClips>();
        onswitchSound = audioClips.sound1;
        offswitchSound = audioClips.sound2;
        gateopenSound = audioClips.sound3;

        anim = Gate.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (count == countanswer)
        {
            
            anim.SetBool("GateOpen", true);

           
            if (flagCache == playOneShotFlag)
            {
                return;
            }

            OnePlaySound();
            flagCache = !flagCache;
            

        }
        else
        {
            
            anim.SetBool("GateOpen", false);
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
            count++;
            audioClips.audioSource.PlayOneShot(onswitchSound);
        }

        if (other.gameObject.tag == "Switch01")
        {
            switch01 = !switch01;

            if (switch01 == true)
            {
                count++;
                audioClips.audioSource.PlayOneShot(onswitchSound);
            }
            else if (switch01 == false)
            {
                count--;
                audioClips.audioSource.PlayOneShot(offswitchSound);
            }
        }

        if (other.gameObject.tag == "Switch02")
        {
            switch02 = !switch02;

            if (switch02 == true)
            {
                count++;
                audioClips.audioSource.PlayOneShot(onswitchSound);
            }
            else if (switch02 == false)
            {
                count--;
                audioClips.audioSource.PlayOneShot(offswitchSound);
            }
        }
    }

    private void OnePlaySound()
    {
        audioClips.audioSource.PlayOneShot(gateopenSound);
    }
}
