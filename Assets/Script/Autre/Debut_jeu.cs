using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debut_jeu : MonoBehaviour
{
    public void debut_jeu()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
