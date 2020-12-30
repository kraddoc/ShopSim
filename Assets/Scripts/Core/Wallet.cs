using System;
using UnityEngine;

namespace SimTask.Core
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private int startingFunds;
        
        public static Wallet Instance;
        public Action BalanceUpdated;
        private int _money;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Add(startingFunds);
        }

        public bool CanAfford(int cost) => _money >= cost;

        public int GetBalance() => _money;
        
        public void Add(int amount)
        {
            if (amount < 0)
            {
                print("Trying to add negative or zero value to wallet");
                return;
            }

            _money += amount;
            BalanceUpdated?.Invoke();
        }

        /// <summary>
        /// Withdraws set amount if can afford.
        /// </summary>
        /// <param name="amount"></param>
        public void TryWithdraw(int amount)
        {
            if (!CanAfford(amount))
                return;

            _money -= amount;
            BalanceUpdated?.Invoke();
        }

        /// <summary>
        /// Withdraws set amount if can afford. If can't, set's balance to negative. Useful for fines and the like.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="onlyPositiveBalance"> Only does the withdrawal with positive funds. </param>
        public void ForceWithdraw(int amount, bool onlyPositiveBalance = false)
        {
            if (onlyPositiveBalance && _money < 0)
                return;
            
            _money -= amount;
            BalanceUpdated?.Invoke();
        }
    }
}
