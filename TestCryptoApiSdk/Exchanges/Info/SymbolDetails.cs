﻿using System;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Exchanges.Info
{
    [TestClass]
    public class SymbolDetails : BaseTest
    {
        [TestMethod]
        public void TestCorrect()
        {
            var symbol = new Symbol("5bfc325c9c40a100014db8ff");
            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Symbol, $"{nameof(response.Symbol)} must not be null");
            Assert.AreEqual("etheur", response.Symbol.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol of null was inappropriately allowed.")]
        public void TestNull()
        {
            Manager.Exchanges.Info.SymbolDetails(symbol: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Symbol.Id of null was inappropriately allowed.")]
        public void TestNullId()
        {
            Manager.Exchanges.Info.SymbolDetails(new Symbol());
        }

        [TestMethod]
        public void TestIncorrectExchange()
        {
            var symbol = new Symbol("QWE'EWQ");
            var response = Manager.Exchanges.Info.SymbolDetails(symbol);

            AssertErrorMessage(response, "Entity not found");
            Assert.IsNull(response.Symbol, $"{nameof(response.Symbol)} must be null");
        }
    }
}