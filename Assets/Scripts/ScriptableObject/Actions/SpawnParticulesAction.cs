
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableAction/SpawnParticulesAction", fileName = "SpawnParticulesAction")]
public class SpawnParticulesAction : ScriptableAction
{
    [SerializeField, TextArea(5, 10)]
    protected string description;

    [SerializeField] private GameObject particulesPrefab;
    [SerializeField] private float autoDestroyTimer = 1.5f;

    public override void PerformAction(GameObject obj)
    {
        GameObject go = Instantiate(particulesPrefab, obj.transform.position, Quaternion.identity);
        Destroy(go, autoDestroyTimer);
    }
}
