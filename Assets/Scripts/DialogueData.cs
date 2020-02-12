using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public class DialogueComponents
    {
        public string[] text;
        public float[] time;
        public AudioClip[] audio;
    }

#region PUBLIC_VERIABLE
    public DialogueComponents diaComp;
    public string Name;
    public Sprite faceSprite;
#endregion
}
