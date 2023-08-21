using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Helps to show turrets allowed to buy
    /// </summary>
    public class Shop : MonoBehaviour
    {
        [SerializeField] private TurretCard[] cards;
        [SerializeField] private TextMeshProUGUI moneyLabel;

        private TurretCollection collection;
        private int money;

        public int Money { get => money; } 

        public void SetUp(TurretCollection turretCollection, int startingMoney)
        {
            money = startingMoney;
            collection= turretCollection;

            for (int i = 0; i < cards.Length; i++)
            {
                if(i+1> collection.turrets.Count)
                {
                    cards[i].gameObject.SetActive(false);
                    continue;
                }    
                cards[i].SetUp(collection.turrets[i]);

            }

            RefreshUI();
        }

        public void UpdateMoney(int delta)
        {
            money += delta;
            RefreshUI();
        }

        private void RefreshUI()
        {
            moneyLabel.text = "$" + money;
            for (int i = 0; i < cards.Length && i < collection.turrets.Count; i++)
            {
                cards[i].interactable = collection.turrets[i].price <= money;
            }
        }
    }
}