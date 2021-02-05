using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyText : MonoBehaviour
{
    [SerializeField] 
    private Text _moneyCountText;
    [SerializeField]
    private Player _player;

    private void OnEnable() {
        _player.MoneyCountChanged += OnMoneyCountChanged;
    }

    private void OnDisable() {
        _player.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int value) {
        _moneyCountText.text = value.ToString();
    }

}
