using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLibrary
{
    /// <summary>
    /// Класс для работы с делителями чисел
    /// </summary>
    public static class Divisors
    {
        /// <summary>
        /// Находит все делители числа N (задача 1)
        /// </summary>
        /// <param name="n">Натуральное число, для которого ищем делители</param>
        /// <returns>Список всех делителей числа в порядке возрастания</returns>
        /// <example>
        /// <code>
        /// FindDivisors(12) => [1, 2, 3, 4, 6, 12]
        /// </code>
        /// </example>
        public static List<int> FindDivisors(int n)
        {
            if (n < 1)
                return new List<int>();

            var divisors = new List<int>();

            // Перебираем возможные делители от 1 до sqrt(n)
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    // Добавляем парный делитель, если он не совпадает с текущим
                    if (i != n / i)
                        divisors.Add(n / i);
                }
            }

            // Сортируем делители по возрастанию
            divisors.Sort();
            return divisors;
        }

        /// <summary>
        /// Подсчитывает количество делителей числа N
        /// </summary>
        /// <param name="n">Натуральное число</param>
        /// <returns>Количество делителей числа</returns>
        public static int CountDivisors(int n)
        {
            return n < 1 ? 0 : FindDivisors(n).Count;
        }

        /// <summary>
        /// Находит числа на интервале [m, n] с ровно 5 делителями (задача 2)
        /// </summary>
        /// <param name="m">Начало интервала</param>
        /// <param name="n">Конец интервала</param>
        /// <returns>Список чисел с ровно 5 делителями</returns>
        public static List<int> FindNumbersWith5Divisors(int m, int n)
        {
            var result = new List<int>();
            for (int i = m; i <= n; i++)
            {
                if (CountDivisors(i) == 5)
                    result.Add(i);
            }
            return result;
        }
    }

    /// <summary>
    /// Класс для работы с простыми числами
    /// </summary>
    public static class PrimeNumbers
    {
        /// <summary>
        /// Проверяет, является ли число простым (по определению)
        /// </summary>
        /// <param name="n">Число для проверки</param>
        /// <returns>True, если число простое</returns>
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Генерирует список первых N простых чисел (задача 4)
        /// </summary>
        /// <param name="count">Количество простых чисел</param>
        /// <returns>Список первых N простых чисел</returns>
        public static List<int> GeneratePrimesByDefinition(int count)
        {
            var primes = new List<int>();
            int num = 2;
            while (primes.Count < count)
            {
                if (IsPrime(num))
                    primes.Add(num);
                num++;
            }
            return primes;
        }

        /// <summary>
        /// Генерирует список первых N простых чисел с помощью решета Эратосфена (задача 5)
        /// </summary>
        /// <param name="count">Количество простых чисел</param>
        /// <returns>Список первых N простых чисел</returns>
        public static List<int> GeneratePrimesBySieve(int count)
        {
            if (count < 1) return new List<int>();

            // Приблизительная оценка верхней границы
            int limit = ApproximateNthPrime(count);

            // Решето Эратосфена
            bool[] sieve = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
                sieve[i] = true;

            for (int i = 2; i * i <= limit; i++)
            {
                if (sieve[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                        sieve[j] = false;
                }
            }

            // Собираем простые числа
            var primes = new List<int>();
            for (int i = 2; i <= limit && primes.Count < count; i++)
            {
                if (sieve[i])
                    primes.Add(i);
            }

            return primes;
        }

        private static int ApproximateNthPrime(int n)
        {
            // Формула для приблизительной оценки n-го простого числа
            if (n < 6) return 15;
            double logN = Math.Log(n);
            return (int)(n * (logN + Math.Log(logN)));
        }
    }

    /// <summary>
    /// Класс для работы с НОД и НОК
    /// </summary>
    public static class NumberTheory
    {
        /// <summary>
        /// Находит наибольший общий делитель (НОД) с помощью алгоритма Евклида (задача 6)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОД чисел a и b</returns>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Находит наименьшее общее кратное (НОК) двух чисел (задача 7)
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>НОК чисел a и b</returns>
        public static int LCM(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            return Math.Abs(a * b) / GCD(a, b);
        }
    }

    /// <summary>
    /// Класс для факторизации чисел
    /// </summary>
    public static class Factorization
    {
        /// <summary>
        /// Факторизует число N (разложение на простые множители)
        /// </summary>
        /// <param name="n">Число для факторизации</param>
        /// <returns>Словарь, где ключи - простые множители, значения - их степени</returns>
        public static Dictionary<int, int> Factorize(int n)
        {
            var factors = new Dictionary<int, int>();
            if (n < 2)
                return factors;

            // Обрабатываем делители 2
            while (n % 2 == 0)
            {
                factors[2] = factors.ContainsKey(2) ? factors[2] + 1 : 1;
                n /= 2;
            }

            // Обрабатываем нечетные делители
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    factors[i] = factors.ContainsKey(i) ? factors[i] + 1 : 1;
                    n /= i;
                }
            }

            // Если остаток - простое число > 2
            if (n > 2)
                factors[n] = 1;

            return factors;
        }

        /// <summary>
        /// Преобразует факторизацию в строковое представление
        /// </summary>
        /// <param name="factors">Словарь с факторизацией</param>
        /// <returns>Строка в формате "p1^k1 * p2^k2 * ... * pn^kn"</returns>
        public static string FactorizationToString(Dictionary<int, int> factors)
        {
            return string.Join(" * ", factors.OrderBy(f => f.Key)
                                          .Select(f => f.Value > 1 ? $"{f.Key}^{f.Value}" : $"{f.Key}"));
        }
    }
}
