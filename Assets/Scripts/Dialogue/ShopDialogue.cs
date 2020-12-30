using SimTask.Core;
using UnityEngine;

namespace SimTask.Dialogue
{
    public class ShopDialogue : MonoBehaviour, IInteractable
    {
        [TextArea(2, 4)] 
        [SerializeField] private string greetText = "Hello, welcome to our shop!";

        [SerializeField] private string answer1 = "I'd like to buy something!";
        [SerializeField] private string answer2 = "I'm just looking.";
        
        private DialogueHandler _dialogueHandler;

        
        
        private void Start()
        {
            _dialogueHandler = DialogueHandler.Instance;
        }

        public void Interact()
        {
            _dialogueHandler.DisplayDialogue(greetText);
            _dialogueHandler.DisplayButtons(answer1, answer2);
        }

        public void DialogueFinish()
        {
            _dialogueHandler.ExitDialogue();
        }
    }
}