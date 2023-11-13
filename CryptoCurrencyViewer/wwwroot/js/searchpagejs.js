
var currentCrypto;

document.addEventListener("DOMContentLoaded", async function (event) {

    saveSearchHistoryToDb(null);


    var token = getToket();

    if (!token) {
        alert("You are not logged in or your session has expired.");
        return;
    }

    await fetch('/Search/GetSearchHistory', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
    })
        .then(response => response.json())
        .then(data => {
            data.forEach(item => {
                saveSearchHistoryLocally(item);
            })
        })
        .catch((error) => console.error('Ошибка:', error));

});



document.getElementById("searchButton").addEventListener("click", async function (event) {



    var token = localStorage.getItem("jwtToken");

    if (!token) {
        alert("You are not logged in or your session has expired.");
        return;
    }

    var inputField = document.getElementById("cryptoId");

    const response = await fetch("/Search/SearchCrypto", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify({
            selectedCrypto: inputField.value
        })
    }).catch((error) => console.error('Error: Unable to save history', error));



    if (response.ok) {
        const result = await response.json();

        currentCrypto = result;

        saveSearchHistoryToDb(result);
        saveSearchHistoryLocally(result);


        document.getElementById("cryptoIcon").src = result.defaultCryptoModel.imageUrl;
        document.getElementById("cryptoName").innerText = `Cryptocurrency ${result.defaultCryptoModel.name}`;
        document.getElementById("cryptoSymbol").innerText = `Symbol: ${result.defaultCryptoModel.symbol}`;
        document.getElementById("cryptoCurrentPrice").innerText = `Current Price: ${result.defaultCryptoModel.currentPrice}`;
        document.getElementById("cryptoMarketCap").innerText = `Market Cap: ${result.defaultCryptoModel.marketCap}`;
        document.getElementById("cryptoVolume24h").innerText = `Volume (24h): ${result.extendedCryptoModel.volume24h}`;
        document.getElementById("cryptoPriceChange24h").innerText = `Price Change (24h): ${result.extendedCryptoModel.priceChangePercentage24h}%`;
        document.getElementById("cryptoHigh24h").innerText = `High (24h): ${result.extendedCryptoModel.high24h}`;
        document.getElementById("cryptoLow24h").innerText = `Low (24h): ${result.extendedCryptoModel.low24h}`;
        document.getElementById("cryptoPriceChange7d").innerText = `Price Change (7d): ${result.extendedCryptoModel.priceChangePercentage7d}%`;
        document.getElementById("cryptoTotalSupply").innerText = `Total Supply: ${result.extendedCryptoModel.totalSupply}`;
        document.getElementById("cryptoMaxSupply").innerText = `Max Supply: ${result.extendedCryptoModel.maxSupply}`;

    } else {
        alert("Crypto name is incorrect");
    }


});




document.getElementById("markFavouriteButton").addEventListener("click", async function (event)
{
    var token = localStorage.getItem("jwtToken");

    if (!token) {
        alert("You are not logged in or your session has expired.");
        return;
    }

    await fetch("/Search/MarkAsFavourite", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(currentCrypto)
    }).catch((error) => console.error('Error: Unable to save history', error));

})

document.getElementById("tradePairsBtn").addEventListener("click", function (event) {
    var token = localStorage.getItem("jwtToken");

    if (!token) {
        alert("You are not logged in or your session has expired.");
        return;
    }

    openSearchPage(currentCrypto);

});




function openSearchPage(crypto) {
    window.location.href = `/Exchanges/ExchangeFrom?crypto=${crypto}`;
}


async function saveSearchHistoryToDb(result) {

    var token = getToket();

    if (token == null) {
        alert("You are not logged in or your session has expired.");
        return;
    }

    await fetch("/Search/SaveSearchHistory", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }//,
        //body: JSON.stringify(result)
            
    }).catch((error) => console.error('Error: Unable to save history', error));
}


function saveSearchHistoryLocally(result) {
    const ul = document.getElementById("search-history");
    const li = document.createElement("li");
    li.textContent = `${result.name} - ${result.symbol}`;
    li.className = "search-history-item";
    li.id = result.name;
    li.addEventListener("dblclick", function () {
        restoreCryptoFromHistory(li.id)
    });
    ul.appendChild(li);

}



///// appeal too c# script get crypto by name   
async function restoreCryptoFromHistory(cryptoName) {
    await fetch("/Search/GetCryptoFromHystoryByNameAsync", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(cryptoName)
            .then(response => response.json())
            .then(data => {
                updateCryptoToNew(data);
            })
    }).catch((error) => console.error('Error: Unable to save history', error));

}

////updates crypto info to another crypto
function updateCryptoToNew(data) {
    document.getElementById("cryptoIcon").src = data.imageUrl;
    document.getElementById("cryptoName").innerText = `Cryptocurrency ${data.name}`;
    document.getElementById("cryptoSymbol").innerText = `Symbol: ${data.symbol}`;
    document.getElementById("cryptoCurrentPrice").innerText = `Current Price: ${data.currentPrice}`;
    document.getElementById("cryptoMarketCap").innerText = `Market Cap: ${data.marketCap}`;
    document.getElementById("cryptoVolume24h").innerText = `Volume (24h): ${data.volume24h}`;
    document.getElementById("cryptoPriceChange24h").innerText = `Price Change (24h): ${data.priceChangePercentage24h}%`;
    document.getElementById("cryptoHigh24h").innerText = `High (24h): ${data.high24h}`;
    document.getElementById("cryptoLow24h").innerText = `Low (24h): ${data.low24h}`;
    document.getElementById("cryptoPriceChange7d").innerText = `Price Change (7d): ${data.priceChangePercentage7d}%`;
    document.getElementById("cryptoTotalSupply").innerText = `Total Supply: ${data.totalSupply}`;
    document.getElementById("cryptoMaxSupply").innerText = `Max Supply: ${data.maxSupply}`;

}




 function getToket() {
    const token = localStorage.getItem('jwtToken'); // Извлекаем токен из хранилища

    // Убедитесь, что токен существует, иначе обработайте отсутствие авторизации
    if (!token) {
        alert("You are not logged in or your session has expired.");
        return null; // Возвращаем null или throw new Error("No token available.");
    }

     return token;
}


