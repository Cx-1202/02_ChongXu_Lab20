using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 10;
    int rotatespeed = 200;
    int gravitymoldifier = 5;
    int jumpcount = 0;
    int jumpforce = 15;

    public AudioClip[] AudioArr;
    public AudioSource BGm;
    public Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb.GetComponent<Rigidbody>();
        Physics.gravity *= gravitymoldifier;

        BGm = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        jumping();

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * Time.deltaTime * -speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotatespeed, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotatespeed, 0));
        }
    }
    private void jumping()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
        {
            BGm.PlayOneShot(AudioArr[0]);
            Rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            jumpcount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumpcount = 0;
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            BGm.PlayOneShot(AudioArr[1]);
            GameManager.gmInstance.OnGoal();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            BGm.PlayOneShot(AudioArr[2]);
        }
    }
}
