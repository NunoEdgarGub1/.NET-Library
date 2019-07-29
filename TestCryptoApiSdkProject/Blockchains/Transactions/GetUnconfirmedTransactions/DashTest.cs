﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetUnconfirmedTransactions
{
    [Ignore]
    [TestClass]
    public class DashTest : BaseBtcSimilarCoin
    {
        protected override BtcSimilarCoin Coin { get; } = BtcSimilarCoin.Dash;
        protected override BtcSimilarNetwork Network { get; } = BtcSimilarNetwork.Testnet;
    }
}