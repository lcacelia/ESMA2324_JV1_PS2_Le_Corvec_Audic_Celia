using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneManager : MonoBehaviour
{
    private int zonesEntered = 0;
    public int totalZones = 3;
    public string nextSceneName;

    public void ZoneEntered()
    {
        zonesEntered++;
        Debug.Log("Zone entered. Total: " + zonesEntered);

        if (zonesEntered >= totalZones)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
