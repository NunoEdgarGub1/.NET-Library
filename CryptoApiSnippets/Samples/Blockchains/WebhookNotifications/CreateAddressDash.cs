﻿using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public string CreateAddressDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
      var address = "1Eeu3eC2b35LWtjXeRMJMSfrDnfDEjNwW6";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateAddress(
          coin, network, url, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateAddressDash executed successfully, HookId is \"" +
          $"{response.Payload.Id}\""
        : $"CreateAddressDash error: {response.ErrorMessage}");

      return response.Payload.Id;
    }
  }
}