﻿
using CryptoCurrencyViewer.Models.Crypto;

namespace CryptoCurrencyViewer.Interfaces;

    public interface IApiService
    {
        public Task<CryptoModel> GetFullCryptoInfoByNameAsync(string cryptoName);

        public Task<DefaultCryptoModel> GetDefaultCryptoInfoByNameAsync(string cryptoName);
}

