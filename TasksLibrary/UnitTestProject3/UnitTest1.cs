using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksLibrary;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(60, new[] { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 })]
        [DataRow(17, new[] { 1, 17 })]
        [DataRow(7, new[] { 1, 7 })]
        [DataRow(1, new[] { 1 })]
        [DataRow(0, new int[0])]
        [DataRow(-7, new int[0])]
        [DataRow(1000, new[] { 1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 1000 })]
        public void Test_lst1(int a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), Divisors.FindDivisors(a)); }

        [DataTestMethod]
        [DataRow(100, 10, new int[0])]
        [DataRow(2, 15, new int[0])]
        [DataRow(15, 16, new[] { 16 })]
        [DataRow(1, 100, new[] { 16, 81 })]
        [DataRow(100, 700, new[] { 625 })]
        [DataRow(1, 1000, new[] { 16, 81, 625 })]
        public void Test_lst2(int a, int b, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), Divisors.FindNumbersWith5Divisors(a, b)); }

        [DataTestMethod]
        [DataRow(12, 12)]
        [DataRow(32, 32)]
        [DataRow(600, 600)]
        [DataRow(9876, 9876)]
        public void Test_lst3(int a, int expected)
        {
            double s = 1;
            foreach (KeyValuePair<int, int> x in Factorization.Factorize(a))
                s *= Math.Pow(x.Key, x.Value);
            Assert.AreEqual(s, expected);
        }

        [DataTestMethod]
        [DataRow(0, new int[0])]
        [DataRow(-2, new int[0])]
        [DataRow(5, new[] { 2, 3, 5, 7, 11 })]
        [DataRow(10, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 })]
        public void Test_lst4(int a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), PrimeNumbers.GeneratePrimesByDefinition(a)); }

        [DataTestMethod]
        [DataRow(1, new[] { 2 })]
        [DataRow(50, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229 })]
        [DataRow(-2, new int[0])]
        public void Test_lst5(int a, int[] expected)
        { CollectionAssert.AreEqual(expected.ToList(), PrimeNumbers.GeneratePrimesBySieve(a)); }

        [DataTestMethod]
        [DataRow(48, 60, 12)]
        [DataRow(30, 45, 15)]
        [DataRow(21, 49, 7)]
        [DataRow(17, 23, 1)]
        [DataRow(5, 5, 5)]
        [DataRow(100, 100, 100)]
        [DataRow(1063, 1, 1)]
        public void Test_lst6(int a, int b, int c)
        { Assert.AreEqual(c, NumberTheory.GCD(a, b)); }

        [DataTestMethod]
        [DataRow(13, 17, 221)]
        [DataRow(4, 6, 12)]
        [DataRow(3, 5, 15)]
        [DataRow(8, 6, 24)]
        [DataRow(10, 15, 30)]
        public void Test_lst7(int a, int b, int c)
        { Assert.AreEqual(c, NumberTheory.LCM(a, b)); }
    }
}