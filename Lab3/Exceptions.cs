using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class FileNotFound: FileNotFoundException{}
    
    public class DirectoryNotFound: DirectoryNotFoundException{}

    public class FileFormatException : FormatException {}
    
    public class InvalidFormat: InvalidCastException{}
    
    public class KeyNotFound: KeyNotFoundException{}

    public class InvalidSyntaxException : Exception
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