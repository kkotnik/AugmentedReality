using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Radio : MonoBehaviour
{
    public Sprite stationSprite;

    [HideInInspector]
    public AudioSource audioSource;

    public List<AudioClip> stationClips;
    
    List<AudioClip> currentStationClips;

    public AudioClip currentClip;
    public int CurrentClipNumber;

    public bool currentRadio;
    public bool stopRadio;

    [HideInInspector]
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShuffleRadio();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentRadio != true && stopRadio != true){
            waitTime -= 1 * Time.deltaTime;
            if(waitTime <= 0){
                audioSource.Stop();
                ShuffleRadio();
                stopRadio = true;
            }
        }
        if (stopRadio != true){
            if (!audioSource.isPlaying){
                CurrentClipNumber += 1;
                if(CurrentClipNumber >= currentStationClips.Count){
                    CurrentClipNumber = 0;
                }
                currentClip = currentStationClips[currentClipNumber];
                audioSource.clip = currentClip;
                audioSource.Play();
            }
        }
    }

    public void ShuffleRadio(){
        currentStationClips = stationClips;
        List<int> numbersTaken = new List<int>();

        for (int i = 0; i < stationClips.Count; i++){
            bool next = false;
            while(next != true){
                int newNumber = Random.Range(0, stationClips.Count);
                if(numbersTaken.Contains(newNumber) != true){
                    currentStationClips[i] = stationClips [newNumber];
                    next = true;
                }
            
            }
        }
    }
}
