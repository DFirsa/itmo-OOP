using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class IniFileNotFound: FileNotFoundException{}
    
    public class MyIniDirectoryNotFound: DirectoryNotFoundException{}

    public class IniFileFormatException : FormatException {}
    
    public class IniFileInvalidFormat: InvalidCastException{}
    
    public class MyIniKeyNotFound: KeyNotFoundException{}

    public class IniInvalidSyntaxException : Exception
    {
        public override string Message {
            get { return "Invalid Syntax Exception"; }
        }
    }

    public class InvalidNamingException : Exception
    {
        public override string Message {
            get { return "Invalid Naming Exception"; }
        }
    }
}