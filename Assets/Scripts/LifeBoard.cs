using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBoard : MonoBehaviour {

    public Image Life1;
    public Image Life2;
    public Image Life3;

    // Update is called once per frame
    void Update () {
        switch (DataManager.Instance.life)
        {
            case 0:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(false);
                break;
            case 1:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(false);
                Life3.gameObject.SetActive(true);
                break;
            case 2:
                Life1.gameObject.SetActive(false);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                break;
            case 3 :
                Life1.gameObject.SetActive(true);
                Life2.gameObject.SetActive(true);
                Life3.gameObject.SetActive(true);
                break;
        }
	}
}
