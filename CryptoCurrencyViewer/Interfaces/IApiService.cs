﻿using CryptoCurrencyViewer.Models;

namespace CryptoCurrencyViewer.Interfaces
{
    public interface IApiService
    {
        public Task<CryptoModel> GetCryptoInfoByNameAsync(string cryptoName);

        public Task<SearchCryptoModel> GetExtendedCryptoInfoByNameAsync(string cryptoName);

    }
}
