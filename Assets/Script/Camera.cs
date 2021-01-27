using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject PlayerGO;
    public Vector3 postoffset = new Vector3(0, 7, -12);
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(17, 0, 0);                
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + postoffset, 0.1f);

        if(Input.GetKey(KeyCode.Tab))
        {
            postoffset = new Vector3(0, 15, -0.9f);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + postoffset, 0.1f);
        }
        else
        {
            postoffset = new Vector3(0, 7, -12);
            transform.rotation = Quaternion.Euler(17, 0, 0);
        }
    }
}
