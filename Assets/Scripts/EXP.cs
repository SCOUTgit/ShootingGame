using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().fillAmount = DataManager.Instance.exp/100f;
    }
}
