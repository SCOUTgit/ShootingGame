using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : MonoBehaviour {

    public float speed = 2f;

    void Update()
    {
        if (!DataManager.Instance.die)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("Damage");
            Destroy(gameObject);
        }
    }
}
