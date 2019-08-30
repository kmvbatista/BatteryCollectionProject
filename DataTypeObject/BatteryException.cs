using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypeObject
{
    
    [Serializable]
    public class BatteryException : Exception
    {
        public List<ErrorField> Errors { get; private set; }
        public BatteryException(List<ErrorField> errors)
        {
            this.Errors = errors;
        }
        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ErrorField error in Errors)
            {
                sb.AppendLine(error.Error);
            }
            return sb.ToString();
        }
        public BatteryException() { }
        public BatteryException(string message) : base(message) { }
        public BatteryException(string message, Exception inner) : base(message, inner) { }
        //BinaryFormatter - .Net Remoting
        protected BatteryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
