using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsSettingManager : MonoBehaviour
{
    public GameObject MercedesW211;
    public GameObject MBsalg;

    void Start() {
        if (PlayerPrefs.GetInt("GraphicsSetting") == 1)
        {
            MercedesW211.SetActive(true);
        } else {
            MBsalg.SetActive(true);
            MercedesW211.SetActive(false);
        }
    }
}
