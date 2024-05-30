using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemydrop : MonoBehaviour
{
    public GameObject dropItem;
    public float dropChance = 0.5f;
    private bool hasDropped = false;

    private void OnDestroy()
    {
        if (!hasDropped && SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            float randomValue = Random.value;

            if (randomValue <= dropChance)
            {
                // Cr�e la SEED
                GameObject SEED = Instantiate(dropItem, transform.position, Quaternion.identity);

              

                hasDropped = true;
            }
        }
    }
}