﻿using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Match2.Partial.Gameplay.Entities
{
    public interface IItemView
    {
        Transform transform { get; }
        GameObject gameObject { get; }
        void Initialize(Sprite sprite);
        void SetSortingOrder(int sortingOrder);
        void Decline();
        UniTask Hide();
        Tween MoveTo(Vector3 position, float duration);
    }
}