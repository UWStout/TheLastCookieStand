using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    int currentConversation = 0;
    int currentLine = 0;
    public float volume = 4f;
    public Text dialogueText;
    public Text nameText;
    public float timeAtEnd;
    public DialogueData[] Dialogue;
    public float DialogueTimeSpent;
    public GameObject dialogueObject;
    AudioSource source;
    bool hasPlayedAudio;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        DialogueTimeSpent += Time.unscaledDeltaTime;
        if (currentLine >= 0)
        {
            int f = Mathf.CeilToInt(Dialogue[currentConversation].diaComp.text[currentLine].Length * (DialogueTimeSpent / Dialogue[currentConversation].diaComp.time[currentLine]));
            int k = Dialogue[currentConversation].diaComp.text[currentLine].Length;
            if (f < k&&f>=0)
            {
                dialogueText.text = Dialogue[currentConversation].diaComp.text[currentLine].Substring(0, f);
            }
            else
            {
                dialogueText.text = Dialogue[currentConversation].diaComp.text[currentLine];
                if (DialogueTimeSpent >= timeAtEnd + Dialogue[currentConversation].diaComp.time[currentLine])
                {
                    NextSnippit();
                }

            }
        }
    }

    public void SetupDialogue(int conv)
    {
        source = GetComponent<AudioSource>();
        currentLine = 0;
        currentConversation = conv;
        nameText.text = Dialogue[currentConversation].Name;
        talk();
    }

    public void NextSnippit()
    {
        currentLine += 1;
        if (Dialogue[currentConversation].diaComp.text.Length <= currentLine)
        {
            endConversation();
            //end Conversation;
        }
        else
        {
            DialogueTimeSpent = 0;
            talk();
            //Put up Text;
            //Put up Audio;
        }
    }

    public void talk()
    {
        ///Can cut the if later.
        ///
        if (Dialogue[currentConversation].diaComp.audio[currentLine]!=null)
        {
            if (hasPlayedAudio) source.Stop();
            source.PlayOneShot(Dialogue[currentConversation].diaComp.audio[currentLine], 4f);
        }


        Debug.Log("Current Line is: " + currentLine);

        hasPlayedAudio = true;
    }

    public void endConversation()
    {

        Time.timeScale = 1;
        dialogueObject.SetActive(false);
    }


}
