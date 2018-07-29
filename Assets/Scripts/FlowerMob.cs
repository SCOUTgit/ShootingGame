using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMob : MonoBehaviour {
    public float hp = 5;
    public float speed = 0.5f;

    public GameObject bullet;

    private void Start()
    {
        hp += DataManager.Instance.level * 10;
        StartCoroutine("Shoot");
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

    IEnumerator Shoot()
    {
        while (!DataManager.Instance.die)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(4f);
        }
    }

    void Damage()
    {
        hp--;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (155f + hp * 20f - DataManager.Instance.level * 10f) / 255);
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
