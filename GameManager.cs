using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int hermit = 0;
    public int isolation = 0;
    public int suppresion = 0;
    public int trying = 0;
    public Button stayHome;
    public Button gotToSchool;
    public Text stayHomeTxt;
    public Text gotoschooltxt;
    public Text dialogueDisp;
    public Button dialogueBox;
    public GameObject background1;
    public GameObject background2;
    public GameObject player;
    public Image ending;
    public string[] dialogues = new string[]{"... !sep! protag", "Ah... !sep! protag", "...It's a new morning. !sep! protag", "... !sep! protag", "... !sep! protag", "...I have to go to school. !sep! protag", "... !sep! protag", "but do you really? !sep! antag", "...huh? !sep! protag", "you should just stay home. !sep! antag", "go back to bed. !sep! antag", "you want to go back to sleep, don't you? !sep! antag", "... !sep! protag", "...shut up. !sep! protag", "nobody would care, you know. !sep! antag", "nobody would notice. !sep! antag.", "just go back to sleep. !sep! antag", "that way, you can't bother anyone. !sep! antag", "... !sep! protag"};
    public string[] hermitDialogue = new string[]{"...okay. !sep! protag", "...but I'm going to text them so they don't worry. !sep! protag", "really? do you think they actually care? !sep! antag", "you're just going to be another annoying notification !sep! antag", "just let them live their own lives. !sep! antag", "...fine. !sep! protag"};
    public string[] goingToSchoolDialogue = new string[]{"No, you're wrong. !sep! protag", "I'm going to school. !sep! protag"};

    public int index = -1;
    // Start is called before the first frame update

    void Start()
    {
        Button dlgBox = dialogueBox.GetComponent<Button>();
        dlgBox.onClick.AddListener(delegate{changeDialogue(dialogues);}); 

        Button stayHomeBtn = stayHome.GetComponent<Button>();
        Button gotToSchoolBtn = gotToSchool.GetComponent<Button>();

        stayHomeBtn.onClick.AddListener(hermitFunc);
        gotToSchoolBtn.onClick.AddListener(sceneChange);

        background1.SetActive(true);
        background2.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeDialogue(string[] dialoguesArr){
        index+=1;

        if(index == dialoguesArr.Length){
            dialogueBox.image.color = new Color(1, 1, 1, 0);
            stayHomeTxt.color = new Color(1, 1, 1, 1);
            gotoschooltxt.color = new Color(1, 1, 1, 1);
        }else{
            string[] dialogueArr = dialoguesArr[index].Split("!sep!");

            if(dialogueArr[0].Contains("I'm going to school")){
                lockers();
            }else{
                if(dialogueArr[1] == " protag"){
                    dialogueBox.image.color = new Color(1, 1, 1, 1);
                    dialogueDisp.color = new Color(0, 0, 0, 1);
                }else{
                    dialogueBox.image.color = new Color(0, 0, 0, 1);
                    dialogueDisp.color = new Color(1, 1, 1, 1);
                }
            }

            StartCoroutine(typewrite());

            IEnumerator typewrite(){
                for(int i = 1; i <= dialogueArr[0].Length; i++){
                    dialogueDisp.text = dialogueArr[0].Substring(0, i);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }

    void sceneChange(){
        index = -1;
        dialogueBox.image.color = new Color(1, 1, 1, 1);
        Button dlgBox = dialogueBox.GetComponent<Button>();
        dlgBox.onClick.RemoveAllListeners();
        dlgBox.onClick.AddListener(delegate{changeDialogue(goingToSchoolDialogue);}); 
        return;
    }
    
    void hermitFunc(){
        hermit += 1;
        index = -1;
        dialogueBox.image.color = new Color(1, 1, 1, 1);
        Button dlgBox = dialogueBox.GetComponent<Button>();
        dlgBox.onClick.RemoveAllListeners();
        dlgBox.onClick.AddListener(delegate{changeDialogue(hermitDialogue);}); 
        Debug.Log("FUCK");
        changeDialogue(hermitDialogue);
        return;
    }

    void lockers(){
        player.transform.position = new Vector2(-10.1f, -1.89f);
        background1.SetActive(false);
        background2.SetActive(true);
    }
}
