using UnityEngine;

public class Enemydrop : MonoBehaviour
{
    public GameObject dropItem;
    public float dropChance = 0.5f;
    private bool hasDropped = false;

    private void OnDestroy()
    {
        if (!hasDropped)
        {
            float randomValue = Random.value;

            if (randomValue <= dropChance)
            {
                // Crée la SEED
                GameObject SEED = Instantiate(dropItem, transform.position, Quaternion.identity);

                // Active la SEED
                SEED.SetActive(true);

                hasDropped = true;
            }
        }
    }
}