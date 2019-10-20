﻿using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.DeleteHdWallet
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(NetworkCoin);
            AssertNullErrorMessage(getWalletsResponse);

            foreach (var wallet in getWalletsResponse.Wallets)
            {
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(NetworkCoin, wallet);

                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {wallet} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondGetWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(NetworkCoin);
            AssertNullErrorMessage(secondGetWalletsResponse);
            AssertEmptyCollection(nameof(secondGetWalletsResponse.Wallets), secondGetWalletsResponse.Wallets);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}