using System;
using UnityEngine;
using UnityEngine.UI;

namespace SimTask.Dialogue
{
    public class DialogueHandler : MonoBehaviour
    {
        public static DialogueHandler Instance;
        [SerializeField] private GameObject dialogueWindow;
        [SerializeField] private GameObject buttonWindow;
        [SerializeField] private Text dialogue;
        [SerializeField] private Text button1;
        [SerializeField] private Text button2;

        private void Awake()
        {
            Instance = this;
        }

        public void DisplayDialogue(string dialogueLine)
        {
            dialogueWindow.SetActive(true);
            dialogue.text = dialogueLine;
        }

        public void DisplayButtons(string button1Text, string button2Text)
        {
            buttonWindow.SetActive(true);
            button1.text = button1Text;
            button2.text = button2Text;
        }

        public void ExitDialogue()
        {
            dialogueWindow.SetActive(false);
            buttonWindow.SetActive(false);
        }
    }
}