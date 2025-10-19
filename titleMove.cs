using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleMove : MonoBehaviour
{
    public float StartPosx;
    public float StartPosy;

    public float Rotx;
    public float Roty;
    public float Rotz;

    public float Posx;
    public float Posy;
    public float Posz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;
        Vector3 pos = transform.position;

        mytransform.Rotate(Rotx,Roty,Rotz,Space.Self);

        transform.Translate(Posx, Posy, Posz,Space.World);

        pos = this.transform.position;
        Debug.Log(pos);

        if (pos.x <= -14.0f)
        {
            transform.position = new Vector3(StartPosx, StartPosy, pos.z);
        }
    }
}
