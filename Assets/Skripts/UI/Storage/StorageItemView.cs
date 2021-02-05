using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StorageItemView : ItemView {

    private int _availableCount = 1;

    public void IncreaseAvailableCount() {
        _availableCount++;
        _availableCountText.text = _availableCount.ToString();
    }

    public override void Render(Item item) {
        base.Render(item);
        _availableCountText.text = _availableCount.ToString();
    }
}
