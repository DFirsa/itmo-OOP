using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Section
    {
        public string Name { get; }
        private Dictionary<string, string> sectionData;

        public Section(string name)
        {
            sectionData = new Dictionary<string, string>();
            this.Name = name;
        }

        public void AddField(string key, string value)
        {
            sectionData.Add(key, value);
        }

        public int GetInt(string key)
        {
            return Int32.Parse(sectionData[key]);
        }

        public float GetFloat(string key)
        {
            return float.Parse(sectionData[key]);
        }

        public string GetString(string key)
        {
            return sectionData[key];
        }
        
    }
}