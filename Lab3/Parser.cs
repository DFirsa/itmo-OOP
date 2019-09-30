using System;
using System.IO;

namespace Lab3
{
    public static class Parser
    {
        public static IniData ParseIni(string path)
        {
            IniData iniData = new IniData();

            string[] lines;

            if (!path.Substring(path.IndexOf('.') + 1, path.Length - path.IndexOf('.') - 1).Equals("ini"))
                throw new FileFormatException();


            try
            {
                lines = File.ReadAllLines(path);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFound();
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFound();
            }

            string sectionName = null;
            foreach (var line in lines)
            {
                string str = line;
                str.Trim();
                str = DeleteComment(str);

                if (str.Length == 0) continue;

                if (str[0].Equals('['))
                {
                    sectionName = str.Substring(1, str.IndexOf(']') - 1);
                    //check naming rules
                    iniData.AddSection(sectionName);
                }
                else if (sectionName == null)
                    continue;
                else
                {
                    string[] lineComponents = str.Split(' ');
                    if (lineComponents.Length == 3)
                        iniData[sectionName].AddField(lineComponents[0], lineComponents[2]);
                    else throw new InvalidSyntaxException();
                }
            }

            return iniData;
        }

        private static string DeleteComment(string line)
        {
            if (line.Contains(";"))
                return line.Substring(0, line.IndexOf(';')).Trim();

            return line;
        }
    }
}