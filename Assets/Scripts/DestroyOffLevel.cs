using UnityEngine;
using System.Collections;

public class DestroyOffLevel : MonoBehaviour {
	
	public float offset = 16f;
	
	public delegate void OnDestroy();
	public event OnDestroy DestroyCallback;
	
	private bool offscreen;
	private float offscreenX = 0;
	
	// Use this for initialization
	void Start () {
		offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}
	
	// Update is called once per frame
	void Update () {
		
		var posX = transform.position.x;
		var posY = transform.position.y;
		
		if (Mathf.Abs (posX) > offscreenX) {
			
			if (posX < -GameController.instance.levelSizePx.x / 2)
            {
				offscreen = true;
			}
            else if (posX > GameController.instance.levelSizePx.x / 2)
            {
				offscreen = true;
			}
            else if (posY < -GameController.instance.levelSizePx.y / 2)
            {
				offscreen = true;
			}
            else if (posY > GameController.instance.levelSizePx.y / 2)
            {
				offscreen = true;
			}
			
		} else {
			offscreen = false;
		}
		
		if (offscreen) {
			OnOutOfBounds();
		}
		
	}
	
	public void OnOutOfBounds(){
		offscreen = false;
		GameObjectUtil.Destroy (gameObject);
		
		if (DestroyCallback != null) {
			DestroyCallback();
		}
		
	}
}


