using System;
using System.Collections.Generic;
using Match2.Common.Extensions;
using UnityEngine;

namespace Match2.Common.UI.Windows
{
    public class WindowsContainer : MonoBehaviour
    {
        private readonly Dictionary<int, WindowBase> windows;
        private readonly Transform transform;
        private RectTransform holder;
        
        internal WindowsContainer(Canvas mainCanvas)
        {
            windows = new Dictionary<int, WindowBase>();
            transform = mainCanvas.transform;

            CreateHolder();
        }
        
        private void CreateHolder()
        {
            var go = new GameObject("Default")
            {
                layer = LayerMask.NameToLayer("UI")
            }; 
            holder = go.AddComponent<RectTransform>();
            holder.SetParent(transform);
            holder.StretchToParent();
        }
        
        public void Add(WindowBase window)
        {
            var type = window.GetType();
            var hashCode = type.GetHashCode();

            if (windows.ContainsKey(hashCode))
                return;
            
            window.Initialize();

            window.RectTransform.SetParent(holder);
            window.RectTransform.StretchToParent();

            windows[hashCode] = window;
        }

        public void Add(RectTransform parent, WindowBase window)
        {
            var type = window.GetType();
            var hashCode = type.GetHashCode();

            if (windows.ContainsKey(hashCode))
                return;
            
            window.Initialize();

            window.RectTransform.SetParent(parent);
            window.RectTransform.StretchToParent();

            windows[hashCode] = window;
        }        
        
        public void Remove(WindowBase window)
        {
            windows.Remove(window.GetType().GetHashCode());
        }

        public bool TryGetWindow(int key, out WindowBase windowBase)
        {
            return windows.TryGetValue(key, out windowBase);
        } 
        
        public bool TryGetWindow(Type windowType, out WindowBase window)
        {
            if (TryGetWindow(windowType.GetHashCode(), out var windowBase))
            {
                window = windowBase;
                return true;
            }

            window = null;
            return false;
        }

        public bool TryGetWindow<T>(out T window) where T : WindowBase
        {
            if (TryGetWindow(typeof(T).GetHashCode(), out var windowBase))
            {
                window = (T) windowBase;
                return true;
            }

            window = null;
            return false;
        }

        public bool ContainsKey(int hashCode)
        {
            return windows.ContainsKey(hashCode);
        }

        public bool Contains<T>() where T : WindowBase
        {
            return ContainsKey(typeof(T).GetHashCode());
        }        
    }
}
