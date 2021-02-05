using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {
    [SerializeField]
    private StorageItemView _template;
    [SerializeField] 
    private Player _player;
    [SerializeField]
    private GameObject _itemContainer;

    private StorageItemView[] _boughtItems;
    private StorageItemView _requiredView;

    private void OnEnable() {
        _player.ItemBought += OnItemBought;
    }

    private void OnDisable() {
        _player.ItemBought -= OnItemBought;
    }

    private void OnItemBought(ShopItemView item) {
        AddItem(item);
    }

    private void AddItem(ShopItemView itemView) {
        _boughtItems = _itemContainer.GetComponentsInChildren<StorageItemView>();

        if (!IsItemBought(itemView.Item, _boughtItems)) {
            _requiredView = null;
            StorageItemView view = Instantiate(_template, _itemContainer.transform);
            view.Render(itemView.Item);
        }
        else {
            _requiredView.IncreaseAvailableCount();
        }
    }

    private bool IsItemBought(Item item, StorageItemView[] boughtItems) {
        bool result = false;

        foreach (StorageItemView itemView in boughtItems) {
            if (itemView.Item == item) {
                result = true;
                _requiredView = itemView;
                break;
            }
        }
        return result;
    }
}
