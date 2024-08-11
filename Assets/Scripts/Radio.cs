using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

        public List<RadioStation> radioStations;
        public int currentStation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRadio(){

    }

    public void NavigateStations(bool value){

        //navigate forward
        if (value == true){
            currentStation +=1;
            if (currentStation >= radioStations.Count){
                currentStation = 0;
            }
        }
        //navigate backwards
        else{
            currentStation -= 1;

            if(currentStation < 0){
                currentStation = radioStations.Count -1;
            }
            PlayRadio();
        }
    }
}
