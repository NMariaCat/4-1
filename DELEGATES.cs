using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _4_1
{
    class DELEGATES<T> where T : IComparable<T>//: IComparable, IComparer//IProvider<T>: IComparable
    {
        //создавать массивы через конструетор
        //int size;
        private T[] array;
        private int _capacity;
        private IProvider<T> _provider;


        /*public interface IComparable<in T>
        {
            int Compare(T? x, T? y);
        }*/
        public DELEGATES(IProvider<T> provider, int size = 100)
        {
            _capacity = size;
            _provider = provider;
            //private T[] array = new T[size];    почему так нельзя? (ошибка в size) ????
            array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = _provider.RandomValue();
            }
        }
        public T[] GetArray()
        {
            return array;
        }
        public T[] add(T newElement)
        {
            if (array.Length == _capacity)
            {

                Array.Resize(ref array, _capacity * 2 + 1);
                array[_capacity] = newElement;  // если не будет работать, то [_capacity+1]
            }
            return array;
        }

        public void erase(string elem)
        {

            int countErase = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (elem.CompareTo(array[i]) == 0)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    countErase++;
                }
            }
            try
            {
                if (countErase == 0) throw new Exception("No such element");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void reverse()
        {
            /* T[] returnArr = new T[array.Length];
             for (int i = 0; i<array.Length; i++)
             {
                 returnArr[i] = array[array.Length-i-1];
             }
            array = returnArr;*/
            Array.Reverse(array);
            //return array;
        }

        public void Do(Action<T> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                action(array[i]);
            }
        }

        public T[] sort()
        {
            Array.Sort(array);
            return array;
        }
        public T[] GetWithCondition(Func<T, bool> function)
        {
            T[] returnArr = new T[array.Length];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (function(array[i]))
                {
                    returnArr[count] = array[i];
                    count++;
                }
            }
            return returnArr;
        }

        public int CountWithCondition(Func<T, bool> condition)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i])) count++;
            }
            return count;
        }

        public bool CheckCondition(Func<T, bool> condition, bool all_or_one)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i])) { count++; }
            }
            if (count == array.Length) return true;
            else if (all_or_one == false && count >= 1) return true;
            else return false;
        }

        public T FirstWithCondition(Func<T, bool> condition)
        {
            try {
                for (int i = 0; i < array.Length; i++)
                {
                    if (condition(array[i])) return array[i];
                }
            }
            catch
            {
                return array[0];
            }
            return array[0];
        }

        public bool CheckElemInArray(T elem)
        {
            /*if (elem == null)
            {
            }
            throw new ArgumentNullException("Неверный ввод");*/

            for (int i = 0; i < array.Length; i++)
            {
                if (elem.CompareTo(array[i]) == 0) return true;
            }
            return false;
        }


        public T[] iteration()
        {
            T[] returnArr = new T[array.Length];
            int count = 0;
            foreach (T item in array)
            {
                returnArr[count] = item;
                count++;
            }
            return returnArr;
        }

        public T MinMax(int number) // number = -1 --> min; number = 1 --> max
        {
            T item = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo( item) == number)
                //if (CompareTo(array[i],item) >0)
                {
                    item = array[i];
                }
            }
            return item;
        }

        public TResult MinMaxProj<TResult>(Func<T, TResult> proj, int number) where TResult: IComparable<T> 
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            TResult result = proj(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                var current = proj(array[i]);
                if (result.CompareTo(current) == number) { result = current; }
            }
            return result;
        }
        public T[] GetNum(int numberOfElem,int index)
        {
            T[] returnArr = new T[array.Length];
            int count = 0;
            for (int i = index; i<numberOfElem; i++)
            {
                returnArr[count] = array[i];
                count++;
            }
            return returnArr;
        }

        public int GetLength() { return array.Length; }

       
        /*public int CompareTo(object? obj)
        {
            return IComparer<T>.Compare(object, obj);
        }*/

        /*static int CompareTo(Object x, Object y)
        {
            return CompareTo(x,y);
        }

        public int CompareTo(object? obj)
        {
            return CompareTo(obj, object);
        }
        static int Compare<T, TResult>(T item1, T item2)
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            return comparer.Compare(item1, item2);
        }*/

        static public int CompareTo(T x, T y)
        {
            Comparer comparer = Comparer.Default;
            return comparer.Compare(x, y);
            //return CompareTo(object x, object y); ;
        }
    }
}




