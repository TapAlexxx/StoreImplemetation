using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour {
    [SerializeField] 
    protected Image _image;
    [SerializeField] 
    protected Text _availableCountText;
    [SerializeField]   
    protected Text _labelText;
    [SerializeField]  
    protected Button _openInfoButton;
    [SerializeField]  
    protected GameObject _infoView;
    [SerializeField] 
    protected Text _descriptionText;
    [SerializeField] 
    protected Button _closeInfoButton;

    public Item Item { get; private set; }


    protected virtual void OnEnable() {
        AddListenersOnEnable();
    }

    protected virtual void OnDisable() {
        RemoveListenersOnDisable();
    }

    private void AddListenersOnEnable() {
        _openInfoButton.onClick.AddListener(OnInfoButtonClick);
        _closeInfoButton.onClick.AddListener(OnCloseInfoButtonClick);
    }

    private void RemoveListenersOnDisable() {
        _openInfoButton.onClick.RemoveListener(OnInfoButtonClick);
        _closeInfoButton.onClick.RemoveListener(OnCloseInfoButtonClick);
    }

    public virtual void Render(Item item) {
        Item = item;
        _image.sprite = item.Image;
        _labelText.text = item.Label;
        _descriptionText.text = item.Description;
    }

    protected void OnInfoButtonClick() {
        _infoView.SetActive(true);
    }

    protected void OnCloseInfoButtonClick() {
        _infoView.SetActive(false);
    }
}
