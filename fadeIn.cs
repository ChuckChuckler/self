using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update
    void Start(){
        StartCoroutine(fadeIn());

        IEnumerator fadeIn(){
            for(float i = 1; i >= 0; i-=0.05f){
                img.color = new Color(0, 0, 0, i);
                yield return new WaitForSeconds(0.1f);
            }
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
