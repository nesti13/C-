using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace OOP_10
{
    class Internet_resours : IList<string>
    {
        List<string> product;
        string internetresours = "";

        public string internetres { get { return internetresours; } }
        public int Count
        {
            get
            {
                return product.Count;
            }
        }
        public bool IsReadOnly { get; set; }

        public Internet_resours(string intepro)
        {
            product = new List<string>();
            internetresours = intepro;
        }
        public Internet_resours(string intepro, params string[] number)
        {
            product = new List<string>();
            internetresours = intepro;
            foreach (string element in number)
            {
                this.Add(element);
            }
        }

        public override string ToString()
        {
            string ri = "Список ассортимента " + internetresours + " : \n";
            foreach (string element in product)
            {
                ri += (element + '\n');
            }
            return ri;
        }

        public int IndexOf(string det)
        {
            for (int i = 0; i < product.Count; i++)
            {
                if (det == product[i]) return i;
            }
            return -1;
        }

        public void Insert(int index, string det)
        {
            if (index < product.Count) product[index] = det;
        }

        public void RemoveAt(int index)
        {
            if (index < product.Count) product.Remove(product[index]);
        }

        public string this[int index]
        {
            get
            {
                return product[index];
            }

            set
            {
                product[index] = value;
            }
        }

        public void Add(string det)
        {
            product.Add(det);
        }

        public void Clear()
        {
            product = new List<string>();
        }

        public bool Contains(string element)
        {
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i] == element) return true;
            }
            return false;
        }

        public void CopyTo(string[] els, int index)
        {
            foreach (string el in els)
            {
                if (index < product.Count) { Insert(index, el); index++; continue; }
                if (index >= product.Count) { Add(el); index++; continue; }
            }
        }

        public bool Remove(string el)
        {
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i] == el) { RemoveAt(i); return true; }
            }
            return false;
        }

        public void Show()
        {
            Console.WriteLine("");
            foreach (string el in product)
            {
                Console.WriteLine(el);
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return product.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return product.GetEnumerator();
        }
    }
}
