using UnityEngine;
using System.Collections;

public class MusicManagerScript : MonoBehaviour {

    public AudioClip MusicClip;
    private AudioSource audioSource;

    public static MusicManagerScript Instance {
        get;
        private set;
    }

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        audioSource.clip = MusicClip;
        audioSource.Play();
    }
}
