
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableAction/SoundAction",fileName = "SoundAction")]
public class SoundAction : ScriptableAction
{
    [SerializeField, TextArea(5, 10)]
    protected string description;

    [SerializeField] private AudioClip soundToPlay;

    public override void PerformAction(GameObject obj)
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        
        if (audioSource != null)
        {
            audioSource.clip = soundToPlay;
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.Play();
        }
    }
}

