using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class ErrorField
    {
        public string PropertyName { get; set; }
        public string Error { get; set; }
        public Exception Exception { get; set; }
    }
}
