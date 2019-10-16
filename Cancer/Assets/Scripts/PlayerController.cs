using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;

    public float speed = 10.0f;
    public float rotationSpeed = 80.0f;
    private Rigidbody playRb;
    private Vector3 moveDirection;
    private Quaternion toRotation;

    private Animator playAnim;

    private int player;

    Transform camera;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        playRb = GetComponent<Rigidbody>();

        playAnim = GetComponent<Animator>();


        camera = transform.Find("Camera");
        camera.transform.LookAt(transform.position + offset);
        camera.transform.RotateAround(transform.position, Vector3.up, transform.rotation.z);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (forwardInput != 0.0f)
        {
            run();
            playAnim.SetFloat("Speed_f", speed / 10);

        }

        if (horizontalInput != 0.0f)
            rotation((horizontalInput > 0) ? (Vector3.right) : (Vector3.left));



        /*if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isOnGround = false;
            playAnim.SetBool("Jump_b", true);
        }*/



    }

    private void OnCollisionEnter(Collision other)
    {

    }

    private void run()
    {
        moveDirection.Set(horizontalInput, 0, forwardInput);

        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection *= Time.fixedDeltaTime * speed;

        moveDirection += transform.position;

        playRb.MovePosition(moveDirection);
    }

    private void rotation(Vector3 i)
    {
        camera = transform.Find("Camera");
        camera.transform.LookAt(transform.position + offset);
        camera.transform.RotateAround(transform.position, Vector3.up, transform.rotation.z);

        toRotation = transform.rotation * Quaternion.LookRotation(Vector3.Scale(moveDirection, i));

        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime);

    }
}
