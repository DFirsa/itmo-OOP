﻿using System;
using System.IO;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IniData iniData = Parser.ParseIni("Example.ini");
            try
            {
                Console.WriteLine(iniData["ADC_DEV"].GetFloat("BufferLenSeconds"));
            }
            catch (Exception e)
            {
                
            }
        }
    }
}