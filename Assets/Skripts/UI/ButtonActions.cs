using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    [SerializeField]
    private GameObject _shop;
    [SerializeField]
    private GameObject _storage;
    [SerializeField]
    private Button _openShop;
    [SerializeField]
    private Button _closeShop;
    [SerializeField] 
    private Button _openStorage;
    [SerializeField]
    private Button _closeStorage;


    private void OnEnable() {
        _openShop.onClick.AddListener(OnOpenShopButtonClick);
        _closeShop.onClick.AddListener(OnCloseShopButtonClick);
        _openStorage.onClick.AddListener(OnOpenStorageButtonClick);
        _closeStorage.onClick.AddListener(OnCloseStorageButtonClick);
    }

    private void OnDisable() {
        _openShop.onClick.RemoveListener(OnOpenShopButtonClick);
        _closeShop.onClick.RemoveListener(OnCloseShopButtonClick);
        _openStorage.onClick.RemoveListener(OnOpenStorageButtonClick);
        _closeStorage.onClick.RemoveListener(OnCloseStorageButtonClick);
    }

    private void OnOpenShopButtonClick() {
        _shop.SetActive(true);
    }

    private void OnCloseShopButtonClick() {
        _shop.SetActive(false);
    }

    private void OnOpenStorageButtonClick() {
        _storage.SetActive(true);
    }

    private void OnCloseStorageButtonClick() { 
        _storage.SetActive(false);
    }
}
