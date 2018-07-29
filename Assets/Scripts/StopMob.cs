using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMob : MonoBehaviour {

    public float hp = 10;
    public float speed=1f;

    private void Start()
    {
        hp += DataManager.Instance.level * 10;
    }

    void Update()
    {
        if(!DataManager.Instance.die)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -4 || hp <= 0)
        {
            if (hp <= 0)
            {
                DataManager.Instance.exp += 10;
                DataManager.Instance.score += 20;
            }
            Destroy(gameObject);
        }
    }

    void Damage()
    {
        hp--;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (155f + hp * 10f - DataManager.Instance.level * 10f) / 255);
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
