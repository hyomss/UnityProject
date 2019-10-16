using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Rigidbody objectRb;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
    objectRb = GetComponent<Rigidbody>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);

            gameManager.UpdateScore(1);
        }

    }
}
