using UnityEngine;
using System.Collections;

public class TiledBackground : MonoBehaviour {

	public int textureSize = 32;
	public bool scaleHorizontially = true;
	public bool scaleVertically = true;

	public Vector2 numTiles = new Vector2(10, 10);

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (numTiles.x * textureSize, numTiles.y * textureSize, 1);

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (numTiles.x, numTiles.y, 1);
	}

}
