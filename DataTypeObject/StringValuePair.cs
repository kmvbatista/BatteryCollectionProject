namespace DataTypeObject
{
    public class StringValuePair
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public StringValuePair(string key, int value)
        {
          Key = key;
          Value = value;
        }
        public StringValuePair()
        {
        }
    }
}