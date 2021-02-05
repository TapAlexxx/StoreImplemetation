using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemView : ItemView {
    private const int MIN_AVAILABLE_COUNT = 50;
    private const int MAX_AVAILABLE_COUNT = 10;

    [SerializeField]
    private Button _sellButton;
    [SerializeField]
    private Text _priceText;

    private int _currentAvailableCount;

    public int CurrenAvailableCount => _currentAvailableCount;

    public event UnityAction<ShopItemView> SellButtonClick;


    override protected void OnEnable() {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        base.OnEnable();
    }

    override protected void OnDisable() {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        base.OnDisable();
    }

    override public void Render(Item item) {
        _currentAvailableCount = Random.Range(MIN_AVAILABLE_COUNT, MAX_AVAILABLE_COUNT);
        _availableCountText.text = _currentAvailableCount.ToString();
        _priceText.text = item.Price.ToString();
        base.Render(item);
    }

    private void OnSellButtonClick() {
        if (_currentAvailableCount > 0) {
            SellButtonClick?.Invoke(this);
        }
    }

    public void ReduceCurrentAvailableCount() {
        _currentAvailableCount--;
        _availableCountText.text = _currentAvailableCount.ToString();
    }
}
