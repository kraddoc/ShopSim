using System;
using SimTask.Core;
using UnityEngine;
using UnityEngine.UI;

namespace SimTask.UI
{
    public class WalletVisualizer : MonoBehaviour
    {
        [SerializeField] private Text balanceUI;
        private Wallet _wallet;
        
        private void Start()
        {
            _wallet = Wallet.Instance;
            _wallet.BalanceUpdated += Refresh;
            Refresh();
        }

        private void Refresh()
        {
            balanceUI.text = _wallet.GetBalance().ToString("N0");
        }
    }
}