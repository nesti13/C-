using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace OOP_10
{
    static class CollectionChange
    {
        public static void Reaction(object sender, NotifyCollectionChangedEventArgs changes)
        {
            switch (changes.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Добавлен новый элемент:");
                    foreach (Internet_resours el in changes.NewItems)
                    {
                        Console.WriteLine(el.ToString());
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Элемент был удален:");
                    foreach (Internet_resours el in changes.OldItems)
                    {
                        Console.WriteLine(el.ToString());
                    }
                    break;
            }
            return;
        }
    }
}
