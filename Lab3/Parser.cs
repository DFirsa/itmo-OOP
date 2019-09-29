namespace Lab3
{
    public static class Parser
    {
        public static IniData ParseIni(string path)
        {
            IniData iniData = new IniData();

            

            return iniData;
        }

        private static string DeleteComment(string line)
        {
            if (line.Contains(";"))
                return line.Substring(0, line.IndexOf(';') + 1);
            else return line;
        }
    }
}