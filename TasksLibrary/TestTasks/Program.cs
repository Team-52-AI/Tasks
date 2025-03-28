using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksLibrary;

namespace TestTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            test_lst(Divisors.FindDivisors(60), new List<int>(){ 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60});
            test_lst(Divisors.FindDivisors(7), new List<int>() { 1, 7 });
            test_lst(Divisors.FindDivisors(1), new List<int>() { 1 });
            test_lst(Divisors.FindDivisors(0), new List<int>());
            test_lst(Divisors.FindDivisors(-7), new List<int>());
            test_lst(Divisors.FindDivisors(1000), new List<int>() { 1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 1000 });
            test_lst(Divisors.FindNumbersWith5Divisors(100, 10), new List<int>());
            test_lst(Divisors.FindNumbersWith5Divisors(2, 15), new List<int>());
            test_lst(Divisors.FindNumbersWith5Divisors(15, 16), new List<int>() { 16 });
            test_lst(Divisors.FindNumbersWith5Divisors(1, 100), new List<int>() { 16, 81 });
            test_lst(Divisors.FindNumbersWith5Divisors(100, 700), new List<int>() { 625 });
            test_lst(Divisors.FindNumbersWith5Divisors(1, 1000), new List<int>() { 16, 81, 625 });
            test_dct(Factorization.Factorize(12), 12);
            test_dct(Factorization.Factorize(32), 32);
            test_dct(Factorization.Factorize(600), 600);
            test_dct(Factorization.Factorize(9876), 9876);
            test_lst(PrimeNumbers.GeneratePrimesByDefinition(0), new List<int>());
            test_lst(PrimeNumbers.GeneratePrimesByDefinition(-2), new List<int>());
            test_lst(PrimeNumbers.GeneratePrimesByDefinition(5), new List<int>() { 2, 3, 5, 7, 11 });
            test_lst(PrimeNumbers.GeneratePrimesByDefinition(10), new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 });
            test_lst(PrimeNumbers.GeneratePrimesBySieve(1), new List<int>() {2});
            test_lst(PrimeNumbers.GeneratePrimesBySieve(50), new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229 });
            test_lst(PrimeNumbers.GeneratePrimesBySieve(-2), new List<int>());
            test_int(NumberTheory.GCD(48, 60), 12);
            test_int(NumberTheory.GCD(30, 45), 15);
            test_int(NumberTheory.GCD(21, 49), 7);
            test_int(NumberTheory.GCD(17, 23), 1); 
            test_int(NumberTheory.GCD(5, 5), 5);
            test_int(NumberTheory.GCD(100, 100), 100);
            test_int(NumberTheory.GCD(1063, 1), 1);
            test_int(NumberTheory.GCD(48, 60), 12);
            test_int(NumberTheory.GCD(48, 60), 12);
            test_int(NumberTheory.LCM(13, 17), 221);
            test_int(NumberTheory.LCM(4, 6), 12);
            test_int(NumberTheory.LCM(3, 5), 15);
            test_int(NumberTheory.LCM(8, 6), 24);
            test_int(NumberTheory.LCM(10, 15), 30);
            Console.Read();
        }

        public static void test_lst(List<int> div, List<int> exp)
        {
           Console.WriteLine(div.SequenceEqual(exp));
        }

        public static void test_dct(Dictionary<int, int> d, int exp)
        {
            double s = 1;
            foreach (KeyValuePair<int, int> x in d) 
                s *= Math.Pow(x.Key, x.Value);
            Console.WriteLine(s == exp);
        }

        public static void test_int(int c, int e)
        {
            Console.WriteLine(e==c);
        }
    }
}
