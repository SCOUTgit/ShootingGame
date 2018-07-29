using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject cam;
    public GameObject endPanel;
    public List<GameObject> mobList;


    private void Start()
    {
        StartCoroutine("MobSpawner");
    }

    private void Update()
    {
        if (DataManager.Instance.exp >= 100 && DataManager.Instance.level < 2)
        {
            DataManager.Instance.level++;
            DataManager.Instance.exp = 0;
        }
        if (DataManager.Instance.life <=0)
        {
            if (DataManager.Instance.bestScore < DataManager.Instance.score)
                DataManager.Instance.bestScore = DataManager.Instance.score;
            StopCoroutine("MobSpawner");
            DataManager.Instance.die = true;
            endPanel.SetActive(true);
        }
    }

    IEnumerator MobSpawner()
    {
        while (true)
        {
            Instantiate(mobList[Random.Range(0, 3)], new Vector3(Random.Range(-2,3), 4.2f, 0), Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator CameraShake()
    {
        for(int i=0; i<3; i++)
        {
            cam.transform.position += Vector3.left*0.1f;
            yield return new WaitForSeconds(0.1f);
            cam.transform.position += Vector3.right*0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }


    public void Restart()
    {

        DataManager.Instance.life = 3;
        DataManager.Instance.exp = 0;
        DataManager.Instance.score = 0;
        DataManager.Instance.level = 0;
        DataManager.Instance.power = 1;
        DataManager.Instance.die = false;
        SceneManager.LoadScene("main");
    }
}
