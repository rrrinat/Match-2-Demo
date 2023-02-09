namespace Match2.Common.Property
{
    [System.Serializable]
    public class ObservablePropertyBool : ObservableProperty<bool>
    {
        public ObservablePropertyBool()
        {
        }

        public ObservablePropertyBool(bool initialValue) : base(initialValue)
        {
        }
    }

    [System.Serializable]
    public class ObservablePropertyInt : ObservableProperty<int>
    {
        public ObservablePropertyInt()
        {
        }

        public ObservablePropertyInt(int initialValue) : base(initialValue)
        {
        }
    }

    [System.Serializable]
    public class ObservablePropertyFloat : ObservableProperty<float>
    {
        public ObservablePropertyFloat()
        {
        }

        public ObservablePropertyFloat(float initialValue) : base(initialValue)
        {
        }
    }
}