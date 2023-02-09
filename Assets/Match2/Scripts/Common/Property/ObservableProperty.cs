namespace Match2.Common.Property
{
    [System.Serializable]
    public class ObservableProperty<T> where T : struct
    {
        public static implicit operator T(ObservableProperty<T> property) => property.Value;

        public delegate void OnPropertyChangeEvent(T from, T to);

        private event OnPropertyChangeEvent OnPropertyChange;

        private T value;

        public T Value
        {
            get => value;
            set
            {
                var oldValue = this.value;
                this.value = value;
                OnPropertyChange?.Invoke(oldValue, value);
            }
        }

        public ObservableProperty()
        {
        }

        public ObservableProperty(T initialValue)
        {
            value = initialValue;
        }

        public void AddListener(OnPropertyChangeEvent listener)
        {
            OnPropertyChange += listener;
        }

        public void RemoveListener(OnPropertyChangeEvent listener)
        {
            OnPropertyChange -= listener;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}