using UnityEngine;
using System.Collections;
using System;

public class PlayerControlledShip : MonoBehaviour, IShootable
{
    private Rigidbody2D body2d;
    private PelletShooter pelletShooter;

    public float turningTorque = 5000f;
    public float forwardThrust = 10000f;
    public float translationalDecelerationFactor = 100f; //force per unit velocity
    public float rotationalDecelerationFactor = .01f; //torque per angular velocity
    public float shotCooldown = .25f; // cooldown time before the plyer can shoot again

    float lastShotTime = 0f;
    // Use this for initialization
    void Awake ()
    {
        body2d = GetComponent<Rigidbody2D>();
        pelletShooter = GetComponent<PelletShooter>();
	}
	
	// Update is called once per frame
	void Update () {

        body2d.AddTorque(0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
			body2d.AddTorque(turningTorque);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
			body2d.AddTorque(-turningTorque);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body2d.AddForce(Utils.VecFromAngleMagnitude(body2d.rotation + 90, forwardThrust));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 decelerationForce = new Vector2(-1 * body2d.velocity.x * translationalDecelerationFactor, -1 * body2d.velocity.y * translationalDecelerationFactor);
            body2d.AddForce(decelerationForce);

            body2d.AddTorque(-1 * body2d.angularVelocity * rotationalDecelerationFactor);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(Time.time - lastShotTime > shotCooldown)
            {
                pelletShooter.Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    public void OnShotBy(GameObject shooter)
    {
		if (shooter.GetComponent ("AIHeavyShip") == null) {
			GameController.instance.Damage(1);
		} else{
			GameController.instance.Damage(3);
		}
      
    }
}
