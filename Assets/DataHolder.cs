using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public int currentLevel = 1;

    public static DataHolder instance;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    public void UpdateHoldingData() {
        currentLevel = LevelManager.instance.currentLevel;
    }
}
