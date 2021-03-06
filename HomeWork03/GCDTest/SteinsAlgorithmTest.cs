﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task;

namespace GCDTest
{
    [TestClass]
    public class SteinsAlgorithmTest
    {
        [TestMethod]
        public void SteinsAlgorithmTestWithTwoNumbers()
        {
            int a = 24;
            int b = 18;
            int expected = 6;

            int actual = GreatestCommonDivisor.SteinsAlgorithm(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SteinsAlgorithmTestWithThreeNumbers()
        {
            int a = 28;
            int b = 42;
            int c = 70;

            int expected = 14;

            int actual = GreatestCommonDivisor.SteinsAlgorithm(a, b, c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SteinsAlgorithmTestWithFourNumbers()
        {
            int a = 24;
            int b = 18;
            int c = 36;
            int d = 72;

            int expected = 6;

            int actual = GreatestCommonDivisor.SteinsAlgorithm(a, b, c, d);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SteinsAlgorithmTestWithFiveNumbers()
        {
            int a = 49;
            int b = 21;
            int c = 147;
            int d = 84;
            int e = 35;

            int expected = 7;

            int actual = GreatestCommonDivisor.SteinsAlgorithm(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }
    }
}
