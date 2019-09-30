using System.Collections.Generic;
using System.Net.Sockets;

namespace Lab3
{
    public class IniData
    {
        private List<Section> Sections;

        public IniData()
        {
            Sections = new List<Section>();
        }
        
        //My exception
        public Section this[string name]
        {
            get
            {
                foreach (var section in Sections)
                    if (section.Name.Equals(name))
                        return section;
                
                throw new KeyNotFoundException();
            }
        }

        public void AddSection(string sectionName)
        {
            Sections.Add(new Section(sectionName));
        }
    }
}