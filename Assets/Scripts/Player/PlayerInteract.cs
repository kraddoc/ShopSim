using System;
using System.Collections.Generic;
using SimTask.Core;
using UnityEngine;

namespace SimTask.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private List<IInteractable> _interactables = new List<IInteractable>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (var interactable in _interactables)
                {
                    interactable.Interact();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactables.Add(interactable);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                _interactables.Remove(interactable);
            }
        }
    }
}