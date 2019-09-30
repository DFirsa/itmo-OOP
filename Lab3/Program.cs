using System;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IniData iniData = Parser.ParseIni("Example.ini");
            
            Console.WriteLine(iniData["NCMD"].GetFloat("SampleRate"));
            
        }
    }
}