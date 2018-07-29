using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int life = 3;
    public int exp = 0;
    public int score = 0;
    public int bestScore = 0;
    public int level = 0;
    public int power = 1;
    public bool die = false;
}
