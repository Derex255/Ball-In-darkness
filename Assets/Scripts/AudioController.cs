using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip loseSound, deathSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void PlayLoseSound()
    {
        audioSource.clip = loseSound;
        audioSource.Play();
    }
    public void PlayDeathSound()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
    }
   
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
