// See https://aka.ms/new-console-template for more information
namespace _4_1;

class Program
{
    static void Main()
    {
        IProvider<int> intProvider = new IntProvider();
        IProvider<string> stringProvider = new StringProvider();
        IProvider<double> doubleprovider = new DoubleProvider();
        /*int SizeInt;
        Console.WriteLine("Добавление элемента.Введите элемент массива, который нужно добавить.");
        intEx.add(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Удаление элемента.Введите элемент массива, который нужно добавить.");
        intEx.erase(Convert.ToInt32(Console.ReadLine()));

        DELEGATES<string> stringEx = new DELEGATES<string>();
        try
        {
            Console.WriteLine("Если Вы хотите задать длину массива int, введите длину, иначе введите 0");
            SizeInt = Convert.ToInt32(Console.ReadLine());
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неверный ввод. Перезапустите программу.");
        }
        DELEGATES<int> intEx = new DELEGATES<int>(SizeInt);
        intEx.sort();
        //bool[] newBoolArray = Where(boolArray, (x) => x != false);]
        intEx.Do((x) => Math.Pow(x,2));*/

        //bool justA = int.TryParse(Console.ReadLine(), out SizeInt);
        /*if (justA == false)
        {
            throw new Exception();
        }
        catch(Exception ex)
        {

        }*/
        //SizeInt = Convert.ToInt32(Console.ReadLine());  // исключения - в классе. можно при неверном вводе автоматически задавать длину и работать дальше
        void _intA()
        {
            int SizeInt = 100;
            Console.WriteLine("Если Вы хотите задать длину массива int, введите длину, иначе введите 0");
            try
            {
                SizeInt = int.Parse(Console.ReadLine());
                if (SizeInt <= 0) throw new Exception("<=0");
            }
            catch
            {
                Console.WriteLine("Неверный ввод. Количество элементов = 100.");
                SizeInt = 100;

            }
            finally
            {
                DELEGATES<int> IntEx = new DELEGATES<int>(intProvider, SizeInt);
                IntEx.sort();
                IntEx.MinMax(-1);
                IntEx.MinMax(1);
                IntEx.MinMaxProj<int>((x) => 2 * x, 1);
                IntEx.MinMaxProj<int>(x => Math.Abs(x), 1);
                Console.WriteLine("Какой элемент вы хотите добавить?");
                try
                {
                    IntEx.add(int.Parse(Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("Неверный ввод, добавлено число 1.");
                    IntEx.add(1);
                }
                //вызов остальных методов (в задании не указано, поэтому закомментированно)
                /*
                int[] a = IntEx.iteration();
                foreach(int i in a)
                {
                    Console.WriteLine(a[i]);    
                }
                Console.WriteLine("Наличие какого элемента в массиве вы хотите проверить?");
                bool IfElemInArr = IntEx.CheckElemInArray(int.Parse(Console.ReadLine()));
                if (IfElemInArr) Console.WriteLine("Этот элемент есть"); else Console.WriteLine("Такого элемента нет");
                int[] res = IntEx.GetWithCondition((x) => x % 2 == 0);
                int countRes = IntEx.CountWithCondition((x) => x % 2 == 0);
                bool CheckCondAll = IntEx.CheckCondition((x) => x % 5 == 0, true);
                bool CheckCondOne = IntEx.CheckCondition((x) => x % 5 == 0, false);
                int firstWithCond = IntEx.FirstWithCondition((x) => x % 10 == 0);


                IntEx.reverse();
                Console.WriteLine("Какой элемент вы хотите стереть?");
                //IntEx.erase(int.Parse(Console.ReadLine()));
                int eraseElem = 0;
                try
                {
                    eraseElem = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный ввод");
                }*/
            }

        }
        void _stringA()
        {
            int SizeStr = 100;
            Console.WriteLine("Если Вы хотите задать длину массива string, введите длину, иначе введите 0");
            try
            {
                SizeStr = int.Parse(Console.ReadLine());
                if (SizeStr <= 0) throw new Exception("<=0");
            }
            catch
            {
                Console.WriteLine("Неверный ввод. Количество элементов = 100.");
                SizeStr = 100;

            }
            finally
            {
                DELEGATES<string> IntEx = new DELEGATES<string>(stringProvider, SizeStr); //может, лучше try-catch сделать в классе?
                IntEx.sort();
                IntEx.MinMax(-1);
                IntEx.MinMax(1);
                IntEx.MinMaxProj<string>((x) => x += "T", 0);
                IntEx.MinMaxProj<string>(x => x += "blablabla", 1);
                Console.WriteLine("Какой элемент вы хотите добавить?");
                try
                {
                    IntEx.add(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный ввод, добавлена сторока /ааа/.");
                    IntEx.add("aaa");
                }
            }
        }
        _intA();
        _stringA();
    }
}



