using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerMovement : MonoBehaviour
{
    //For Movement
    [Header("Movement")]
    public CharacterController controller;
    public float walkSpeed;

    // public GameObject Baddie;

    //For Health
    [Header("Health")]
    //public int health;
    //public float NumOfHealth;
    //public Image[] Hearts;

    //Stuff
    public static Transform Clone;
    private void Awake()
    {
        Clone = this.transform;
    }

    public Transform Enemies;
    public float OverlapRadius = .2f;
    private int enemyLayer;
    public Transform Player;

    //
    public int Damage;

    // Start is called before the first frame update
    public void Start()
    {
        health = 3;
        Damage = 1;
    }

    // Update is called once per frame
    public void Update()
    {

        //the character's movement
        Vector3 movement = new Vector3();

        float forwardMovement = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

        controller.Move(movement);

        //Player's Health System
        if (health == 0)
        {
            Debug.Log("Im dead");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);
            health = health - 1;
            Debug.Log("Works");
        }
    }


    private void LookAtBad()
    {
        transform.LookAt(Enemies);
        Vector3 direction = Enemies.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
}