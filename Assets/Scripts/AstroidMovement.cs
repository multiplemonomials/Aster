﻿using UnityEngine;
using System.Collections;

public class AstroidMovement : MonoBehaviour {

 Rigidbody2D body2d;
	public float AsteroidSpeed = 1f;
	public float SpeedOffset = 1f;
	public float SpawnArea = 1f;

	void Awake ()
	{
		body2d = GetComponent<Rigidbody2D>();
	}
	void Start () {
		var Angle = Random.Range (0, 360);
		var SpawnLocationX = body2d.transform.position.x + Random.Range (-SpawnArea, SpawnArea);
		var SpawnLocationY = body2d.transform.position.y + Random.Range (-SpawnArea, SpawnArea);
		body2d.velocity = Utils.VecFromAngleMagnitude (Angle, AsteroidSpeed + Random.Range (-SpeedOffset, SpeedOffset));
		transform.position = new Vector2 (SpawnLocationX, SpawnLocationY);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
