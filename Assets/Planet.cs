﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Initialize();
    }

    public void Initialize()
    {
        transform.localScale = new Vector3(0.2f, 0.2f,0);
    }

    private void CheckKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        FindObjectOfType<Bullet>().GetComponent<Bullet>().fired = true;
		GameObject.Find("BGM Controller").GetComponent<BGMController>().RocketSoundHigh();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Add score
        //CameraShift
        FindObjectOfType<Envelope>().GetComponent<Envelope>().Show();
        collider.GetComponent<Bullet>().fired = false;
        collider.GetComponent<Bullet>().motherPlanet = transform;
        collider.GetComponent<Bullet>().NewPlanet();
		GameObject.Find("BGM Controller").GetComponent<BGMController>().RocketSoundLow();
    }

    // Update is called once per frame
    void Update () {
        CheckKeys();
	}

}