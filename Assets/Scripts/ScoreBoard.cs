using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public List<Sprite> number;
    public Image Score1;
    public Image Score2;
    public Image Score3;
    public Image Score4;
    public bool best;

	// Update is called once per frame
	void Update () {
        if (best) {
            if (DataManager.Instance.bestScore < 10)
            {
                Score4.sprite = number[DataManager.Instance.bestScore % 10];
            }
            else if (DataManager.Instance.bestScore < 100)
            {
                Score3.gameObject.SetActive(true);
                Score3.sprite = number[DataManager.Instance.bestScore / 10];
                Score4.sprite = number[DataManager.Instance.bestScore % 10];
            }
            else if (DataManager.Instance.bestScore < 1000)
            {
                Score2.gameObject.SetActive(true);
                Score3.gameObject.SetActive(true);
                Score2.sprite = number[DataManager.Instance.bestScore / 100];
                Score3.sprite = number[DataManager.Instance.bestScore % 100 / 10];
                Score4.sprite = number[DataManager.Instance.bestScore % 10];
            }
            else
            {
                Score1.gameObject.SetActive(true);
                Score2.gameObject.SetActive(true);
                Score3.gameObject.SetActive(true);
                Score1.sprite = number[DataManager.Instance.bestScore / 1000];
                Score2.sprite = number[DataManager.Instance.bestScore % 1000 / 100];
                Score3.sprite = number[DataManager.Instance.bestScore % 100 / 10];
                Score4.sprite = number[DataManager.Instance.bestScore % 10];
            }
        }
        else {
            if (DataManager.Instance.score < 10)
            {
                Score4.sprite = number[DataManager.Instance.score % 10];
            }
            else if (DataManager.Instance.score < 100)
            {
                Score3.gameObject.SetActive(true);
                Score3.sprite = number[DataManager.Instance.score / 10];
                Score4.sprite = number[DataManager.Instance.score % 10];
            }
            else if (DataManager.Instance.score < 1000)
            {
                Score2.gameObject.SetActive(true);
                Score3.gameObject.SetActive(true);
                Score2.sprite = number[DataManager.Instance.score / 100];
                Score3.sprite = number[DataManager.Instance.score % 100 / 10];
                Score4.sprite = number[DataManager.Instance.score % 10];
            }
            else
            {
                Score1.gameObject.SetActive(true);
                Score2.gameObject.SetActive(true);
                Score3.gameObject.SetActive(true);
                Score1.sprite = number[DataManager.Instance.score / 1000];
                Score2.sprite = number[DataManager.Instance.score % 1000 / 100];
                Score3.sprite = number[DataManager.Instance.score % 100 / 10];
                Score4.sprite = number[DataManager.Instance.score % 10];
            }
        }
    }
}
