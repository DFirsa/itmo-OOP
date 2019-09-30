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
            try
            {
                return Int32.Parse(sectionData[key]);
            }
            catch (InvalidCastException)
            {
                throw new InvalidFormat();
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFound();
            }
        }

        public float GetFloat(string key)
        {
            try
            {
                return float.Parse(sectionData[key]);
            }
            catch (InvalidCastException)
            {
                throw new InvalidFormat();
            }
            catch
            {
                throw new KeyNotFound();
            }
        }

        public string GetString(string key)
        {
            try
            {
                return sectionData[key];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFound();
            }
        }
        
    }
}