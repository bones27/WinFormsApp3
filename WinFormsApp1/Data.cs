namespace ReadForSpeed
{
    internal class Data
    {
        Dictionary<string, int> _data;
        public string[] asList => List();
        public Data() {
            _data = new Dictionary<string, int>();
        }

        public void Set(string key, int value)
        {
            if (_data.ContainsKey(key))
            {
                _data[key] = value;
            }
            else
            {
                _data.Add(key, value);
            }
        }

        public int Get(string key)
        {
            return _data[key];
        }

        public string[] List()
        {
            return _data.Keys.ToArray();
        }
        public void Load(string fn)
        {
            if (File.Exists(fn))
            {
                var json = File.ReadAllText(fn);
                _data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, int>>(json);
            }
        }

        public void Save(string fn)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(_data);
            File.WriteAllText(fn, json);
        }
        

    }
}
