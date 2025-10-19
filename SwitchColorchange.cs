using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColorchange : MonoBehaviour
{
    private Material material;
    private bool switchs=false;
    // Start is called before the first frame update
    void Start()
    {
        this.material = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchs == true)
        {
            material.color = new Color32(240, 240, 0,1);
        }
        else if (switchs == false)
        {
            material.color = new Color32(200, 200, 200,1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collab")
        {
            switchs = !switchs;
            Debug.Log(switchs);
        }
    }
}
