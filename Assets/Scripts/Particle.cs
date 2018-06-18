using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : Token {

	static GameObject _prefab = null;
	public static Particle Add(float x, float y) {
		_prefab = GetPrefab(_prefab, "Particle");
		return CreateInstance2<Particle>(_prefab, x, y);
	}

	// コルーチンで処理を行う
	IEnumerator Start () {
		// 移動方向と高さをランダムに決める
		float dir = Random.Range(0, 359);
		float speed = Random.Range(10.0f, 20.0f);
		SetVelocity(dir, speed);

		while (ScaleX > 0.01f) {
			yield return new WaitForSeconds(0.01f);

			MulScale(0.9f);
			MulVelocity(0.9f);
		}

		DestroyObj();
	}
}
