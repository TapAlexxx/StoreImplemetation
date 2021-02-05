using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    [SerializeField]
    private List<Item> _sellItems;
    [SerializeField]
    private ShopItemView _template;
    [SerializeField]
    private GameObject _itemContainer;
    [SerializeField]
    private Player _player;

    private List<ShopItemView> _renderedItemViews = new List<ShopItemView>();


    private void Start() {
        AddItemToShop();
    }

    private void OnDisable() {
        UnSubscribeOnDisable();
    }

    private void UnSubscribeOnDisable() {
        if (_renderedItemViews.Count > 0) {
            foreach (var item in _renderedItemViews) {
                item.SellButtonClick -= OnSellButtonClick;
            }
        }
    }

    private void AddItemToShop() {
        for (int i = 0; i < _sellItems.Count; i++) {
            AddItemToShop(_sellItems[i]);
        }
    }

    private void AddItemToShop(Item item) {
        ShopItemView view = Instantiate(_template, _itemContainer.transform);
        _renderedItemViews.Add(view);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(item);
    }

    private void OnSellButtonClick(ShopItemView itemView) {
        _player.TryBuyItem(itemView);
    }
}
