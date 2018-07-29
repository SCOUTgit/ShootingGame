using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public List<GameObject> Bullet;
    public GameObject Track;
    public float moveTime;
    public float shootingTime;

    private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine("Road");
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update () {
        if(!DataManager.Instance.die)
            Move();
    }

    void Move()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -2.4 && Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 2.4)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
        }
        else if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= -2.4)
        {
            transform.position = new Vector3(-2.4f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(2.4f, transform.position.y, transform.position.z);
        }
    }

    IEnumerator Shoot()
    {
        while (!DataManager.Instance.die)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bullet[DataManager.Instance.level], transform.position, Quaternion.Euler(0, 0, 0));
            }
            yield return new WaitForSeconds(shootingTime);
        }
    }

    IEnumerator Road()
    {
        while (!DataManager.Instance.die)
        {
            Instantiate(Track, transform.position+Vector3.down*0.3f, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(moveTime);
        }
    }

    void Damage()
    {
        DataManager.Instance.life--;
    }
}
