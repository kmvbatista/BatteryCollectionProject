using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypeObject
{
    public class KeyValueDiscards
    {
        public int Key { get; set; }
        public int Discards { get; set; }

        public KeyValueDiscards(int key, int discards)
        {
            Key = key;
            Discards = discards;
        }
    }
}