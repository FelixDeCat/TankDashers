﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 1;
    public Vector3 v3;
    [Header("For Random")]
    public bool random;
    public int random_range;
    float timer;
    public float timetochangerandom = 1;

    private void Awake()
    {
        timer = timetochangerandom + 1;
    }

    void Update ()
    {
        if (random) {
            if (timer < timetochangerandom) timer = timer + 1 * Time.deltaTime;
            else {
                v3 = new Vector3(
                    Random.Range(-random_range, random_range), 
                    Random.Range(-random_range, random_range), 
                    Random.Range(-random_range, random_range));
                timer = 0;
            }
        }

        transform.Rotate(v3.x * speed, v3.y * speed, v3.z * speed);
    }
}
