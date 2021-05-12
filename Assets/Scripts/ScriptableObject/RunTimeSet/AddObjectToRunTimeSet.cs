using UnityEngine;

public class AddObjectToRunTimeSet : MonoBehaviour
{

    public GameObjectRunTimeSet gameObjectRunTimeSet;

    private void OnEnable()
    {
        gameObjectRunTimeSet.AddItem(gameObject);
    }

    private void OnDisable()
    {
        gameObjectRunTimeSet.RemoveItem(gameObject);

    }
  
}

