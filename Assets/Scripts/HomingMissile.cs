//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;

public class HomingMissile : Projectile
{
	public float acceleration;
	public float startingVelocity;
	public GameObject thingToHomeOn;

	private Rigidbody2D body2d;
	private float currentVelocity;

	new void Awake()
	{
        base.Awake();

		body2d = GetComponent<Rigidbody2D>();
		thingToHomeOn = GameController.instance.playerShipInstance;
		currentVelocity = startingVelocity;
	}

	void FixedUpdate()
	{
		if(thingToHomeOn != null)
		{
			PolarVec2 targetPosPolar = PolarVec2.FromCartesian(((Vector2)thingToHomeOn.transform.position) - ((Vector2)transform.position));

			//adjust missile rotation
			Vector3 newRotation = transform.rotation.eulerAngles;
			newRotation.z = targetPosPolar.A - 90;
			transform.rotation = Quaternion.Euler(newRotation);
			
			//handle acceleration
			currentVelocity += acceleration * Time.deltaTime;
			
			body2d.velocity = targetPosPolar.Cartesian2D.normalized * currentVelocity;
		}

	}
}


