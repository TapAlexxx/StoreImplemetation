using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _startMoneyCount;

    public int CurrentMoneyCount { get; private set; }

    public event UnityAction<ShopItemView> ItemBought;
    public event UnityAction<int> MoneyCountChanged;


    private void Start() {
        CurrentMoneyCount = _startMoneyCount;

        MoneyCountChanged?.Invoke(CurrentMoneyCount);
    }

    public void TryBuyItem(ShopItemView itemView) {
        if (CurrentMoneyCount > itemView.Item.Price) {
            CurrentMoneyCount -= itemView.Item.Price;
            itemView.ReduceCurrentAvailableCount();
            MoneyCountChanged?.Invoke(CurrentMoneyCount);
            ItemBought?.Invoke(itemView);
        }
    }
}
