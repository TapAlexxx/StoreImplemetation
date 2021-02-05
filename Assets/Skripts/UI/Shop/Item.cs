using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item", order = 51)]
public class Item : ScriptableObject {
    [SerializeField]
    private Sprite _image;
    [SerializeField]
    private string _label;
    [SerializeField]
    private int _price;
    [SerializeField] 
    private string _descripton;


    public Sprite Image => _image;
    public string Label => _label;
    public int Price => _price;
    public string Description => _descripton;
}
