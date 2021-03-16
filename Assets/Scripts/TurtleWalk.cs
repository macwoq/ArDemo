
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurtleWalk : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    public float speed = 5;
    bool canWalk = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    PlayTurtle();

                }
                else
                {
                    Debug.Log("This isn't a Marker");
                }
            }

        }

        if (canWalk)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }
    public void PlayTurtle()
    {
        canWalk = true;
        var turtle = GameObject.Find("Turtle").GetComponent<Animator>();
        turtle.SetBool("Walk", true);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(clip);

    }


}