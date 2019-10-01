using System;
using System.IO;
using System.Linq;

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
                    if (!IsValidNaming(sectionName)) throw new InvalidNamingException();
                    iniData.AddSection(sectionName);
                }
                else if (sectionName == null)
                    throw new InvalidSyntaxException();
                else
                {
                    string[] lineComponents = str.Split('=');
                    if (lineComponents.Length == 2)
                    {
                        string fieldName = lineComponents[0].Trim();
                        if (!IsValidNaming(fieldName))
                            throw new InvalidNamingException();
                        iniData[sectionName].AddField(fieldName, lineComponents[1].Trim());
                    }
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

        private static bool IsLatinLetter(char ch)
        {
            return (int) 'a' <= (int) Char.ToLower(ch) && (int) 'z' >= (int) Char.ToLower(ch);
        }
        
        private static bool IsValidNaming(string name)
        {
            int count = 0;
            foreach (var ch in name.ToCharArray())
                if (Char.IsDigit(ch) || IsLatinLetter(ch) || ch.Equals('_'))
                    count++;

            return count == name.Length;
        }

    }
}