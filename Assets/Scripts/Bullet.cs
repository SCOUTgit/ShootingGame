using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;

	void Update () {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
        if (transform.position.y > 5)
            Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.gameObject.SendMessage("Damage");
            Destroy(transform.parent.gameObject);
        }
    }
}
