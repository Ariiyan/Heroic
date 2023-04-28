using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnTrigger : MonoBehaviour
{
    public AudioClip clip;
    public string targetTag;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void onTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            source.PlayOneShot(clip);
        }
    }
}
