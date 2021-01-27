using System;
using System.Collections.Generic;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dictionary = new Dictionary<string, string>();
            dictionary.Add("a","Fırat");


            System.Console.WriteLine(dictionary.Count); 
            MyDictionary<int,string> dictionary1 = new MyDictionary<int, string>();
            dictionary1.Add(1,"Fırat");
            dictionary1.Add(2,"Fırat2");
            dictionary1.Add(3,"Fırat3");

            foreach(var item in dictionary1.Values)
            {
                System.Console.WriteLine("Değer : "+item);
            }
            foreach(var item in dictionary1.Keys)
            {
                System.Console.WriteLine("Anahtar : "+item);
            }
            Console.WriteLine(dictionary1.Count);
        }
    }
    class MyDictionary<T,T2>
    {
        T[] _keys,tempKeys;
        T2[] _values,tempValues;
        public MyDictionary()
        {
            _keys = new T[0];
            _values = new T2[0];
        }
        public void Add(T key,T2 value)
        {

            tempKeys=_keys;
            tempValues=_values;
            _keys = new T[tempKeys.Length+1];
            _values=new T2[tempValues.Length+1];
            for (int i = 0; i < tempKeys.Length; i++)
            {
                _keys[i]=tempKeys[i];
                _values[i]=tempValues[i];
            }
            _keys[_keys.Length-1]=key;
            _values[_values.Length-1]=value;
        }
        public int Count
        {
            get { return _keys.Length; }
        }
        public T2[] Values
        {
            get { return _values; }
        }
        public T[] Keys
        {
            get { return _keys; }
        }
        
    }
}
