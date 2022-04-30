using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rotSpeed = 100f;

    [SerializeField] float flySpeed = 100f;

    Rigidbody rigidBody;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Launch();
    }
    void OnCollisionEnter(Collision collision) 
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
            print("OK!");
            break;
            case "Battery":
            print("PLUSEnergy!");
            break;
            default:
            print("MINUSEnergy!");
            break;
        }
    }
    void Launch()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * flySpeed);
            if(audioSource.isPlaying == false);
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

    void Rotation()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime;    

        rigidBody.freezeRotation = true;
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }
}
