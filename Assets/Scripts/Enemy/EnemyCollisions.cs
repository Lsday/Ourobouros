using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour
{
    private Vector3 screenBounds;

    public void BeeingDestroy(GameObject gameObj)
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        int randomX = Random.Range((int)-screenBounds.x, (int)screenBounds.x);
        int randomY = Random.Range((int)-screenBounds.y, (int)screenBounds.y);


        Instantiate(GameAssets.instance.fruitPrefab,new Vector3(randomX,randomY,0),Quaternion.identity);

        Destroy(gameObject);
    }

   
}
