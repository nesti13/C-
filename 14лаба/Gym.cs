using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace _14
{
    [DataContract]
    [Serializable]
    public class Gym
    {
        public Gym()
        { }
        [DataMember]
        public string Name { get; set; }

        public string Master { get; set; }

        public Gym(string name, string master)
        {
            Name = name;
            Master = master;
        }

        public override string ToString()
        {
            return $"Зал {Name}, тренер {Master}";
        }
    }
}
