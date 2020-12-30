using System;
using SimTask.Player;
using UnityEngine;

namespace SimTask.UI
{
    public class TradeWindowVisualizer : MonoBehaviour
    {
        [SerializeField] private GameObject playerInventory;
        [SerializeField] private GameObject itemDescriptor;
        [SerializeField] private GameObject shopInventory;



        public void CloseAll()
        {
            PlayerState.CurrentState = PlayerState.State.Free;
            itemDescriptor.SetActive(false);
            shopInventory.SetActive(false);
        }
        
        public void DisplayTradeMenu()
        {
            CloseAll();
            PlayerState.CurrentState = PlayerState.State.Trading;
            playerInventory.SetActive(true);
            itemDescriptor.SetActive(true);
            shopInventory.SetActive(true);
        }
    }
}