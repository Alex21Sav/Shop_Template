using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private float _coins;
    [SerializeField] private int _stars;
    [SerializeField] private float _activationsTime;
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;

    public float Coins => _coins;
    public float Stars => _stars;
    public float ActivationsTime => _activationsTime;
    public string Lable => _lable;
    public Sprite Icon => _icon;

    public void Buy()
    {
        Debug.Log("Item purchase bonus");
    }
}
