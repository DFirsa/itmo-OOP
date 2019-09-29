using System.Collections.Generic;

namespace Lab3
{
    public class IniData
    {
        private List<Dictionary<string, string>> Sections;

        public IniData()
        {
            Sections = new List<Dictionary<string, string>>();
        }
    }
}