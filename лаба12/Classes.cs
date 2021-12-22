using System;
using System.Collections.Generic;
using System.Text;

namespace _12
{
    class Serial : ICloneable
    {
        private string name;
        private string director;

        public Serial(string Name, string Director)
        {
            name = Name;
            director = Director;
        }
        public string Director
        {
            get => director;
            set => director = value;
        }
        public string Name => name;

        public void GetId(int i) => Console.WriteLine(Convert.ToInt32(name[0]) * i);
        public object Clone() => MemberwiseClone();

    }
}
