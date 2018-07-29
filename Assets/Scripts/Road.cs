using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public float speed;

	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4)
            Destroy(gameObject);
	}
}
