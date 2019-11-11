using System;
using System.Collections.Generic;
using System.Globalization;

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
                throw new IniFileInvalidFormat();
            }
            catch (KeyNotFoundException)
            {
                throw new MyIniKeyNotFound();
            }
        }

        public float GetFloat(string key)
        {
            try
            {
                return float.Parse(sectionData[key], CultureInfo.InvariantCulture);
            }
            catch (InvalidCastException)
            {
                throw new IniFileInvalidFormat();
            }
            catch
            {
                throw new MyIniKeyNotFound();
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
                throw new MyIniKeyNotFound();
            }
        }
        
    }
}