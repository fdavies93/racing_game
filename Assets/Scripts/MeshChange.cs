﻿using UnityEngine;
using System.Collections;

public class MeshChange : MonoBehaviour {

    public float meshHealth;

    CarController carController;

    ChildInfo childInfo;

    Rigidbody rb;

    public bool looseParts = true;

    public bool alreadyDetached = false;

    // backward is not defined because is by default
    public bool forward = false;
    public bool left = false;
    public bool right = false;
    public bool up = false;

    void Awake()
    {
        carController = transform.root.GetComponent<CarController>();
        childInfo = transform.GetChild(0).GetComponent<ChildInfo>();
    }

    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        gameObject.transform.GetChild(1).GetComponent<Renderer>().enabled = false;
        meshHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (meshHealth >= 100)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<Renderer>().enabled = false;
        }
        else if (meshHealth > 0 && meshHealth < 80)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<Renderer>().enabled = true;
        }
        else if (meshHealth <= 0 && looseParts && !alreadyDetached)
        {
            addRigidBody(this.gameObject);
            alreadyDetached = true;
        }
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Enviroment")
    //    {
    //        Debug.Log("something hit");
    //        meshHealth -= carController.currentSpeed * .1f;
    //    }
        

    //    Debug.Log("collision");
    //    meshHealth -= 10;
    //}

    void FixedUpdate()
    {
        Vector3 direction;

        if (forward)
            direction = this.transform.forward;
        else if(left)
            direction = -this.transform.right;
        else if (right)
            direction = this.transform.right;
        else if (up)
            direction = this.transform.up;
        else // backward is by default
            direction = -this.transform.forward;

        Debug.DrawRay(childInfo.GetPosition(), direction * 1, Color.magenta);

        if (Physics.Raycast(childInfo.GetPosition(), direction, 2.4f))
        {
            // Do something if hit

            //Debug.Log("position : " + childInfo.GetPosition() + " "+ childInfo.name);
            meshHealth -= carController.currentSpeed * .1f;
        }
    }

    private void addRigidBody(GameObject gameObject)
    {
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        //rigidBody.mass = 1;
        //rigidBody.useGravity = true;
        //foreach (Transform t in gameObject.transform)
        //{
        //    addRigidBody(t.gameObject);
        //}
    }
}
