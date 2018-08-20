using UnityEngine;
using System.Collections;

public class Enemy : Token {

	// 生存数
  	public static int Count = 0;

	// Use this for initialization.
	void Start () {

		// 生存数を増やす
    	Count++;

		// Set size.
		SetSize(SpriteWidth / 2, SpriteHeight / 2);

		// move to random direction.
		// determine direction.
		float dir = Random.Range(0, 359);
		// determine speed 2.
		float spd = 2;
		SetVelocity(dir, spd);
		Debug.Log(dir);
	}

	// update
	void Update () {
		// get left bottom side coordinate
		Vector2 min = GetWorldMin();
		// get right up side coordinate
		Vector2 max = GetWorldMax();

		if (X < min.x || max.x < X) {
			// if out of field , change direction
			VX *= -1;
			// move inside display
			ClampScreen();
		}

		if (Y < min.y || max.y < Y) {
			// if out of field , change direction
			VY *= -1;
			// move inside display
			ClampScreen();
		}
	}

	public void OnMouseDown() {

		// 生存数を減らす
    	Count--;

		// delete Object
		DestroyObj();

		// パーティクルを生成
    	for (int i = 0; i < 16; i++)
    	{
      		Particle.Add(X, Y);
    	}

	}

}
