using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    private Vector2 startPosition;
    private float spawnTime;
    public float speed;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPosition + Vector2.up * (Time.time - spawnTime) * speed;
    }
}
