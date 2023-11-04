
var currentCrypto;

document.addEventListener("DOMContentLoaded", async function (event) {



    await fetch('/Search/GetSearchHistory')
        .then(response => response.json())
        .then(data => {
            data.forEach(item => {
                saveSearchHistoryLocally(item);
            })
        })
        .catch((error) => console.error('Ошибка:', error));

});



document.getElementById("searchbutton").addEventListener("click", async function (event) {

    var inputField = document.getElementById("cryptoId");

    const response = await fetch("/Search/SearchCrypto", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            selectedCrypto: inputField.value
        })

    });



    if (response.ok) {
        const result = await response.json();

        saveSearchHistoryToDb(result);
        saveSearchHistoryLocally(result);


        document.getElementById("cryptoIcon").src = result.imageUrl;
        document.getElementById("cryptoName").innerText = `Cryptocurrency ${result.name}`;
        document.getElementById("cryptoSymbol").innerText = `Symbol: ${result.symbol}`;
        document.getElementById("cryptoCurrentPrice").innerText = `Current Price: ${result.currentPrice}`;
        document.getElementById("cryptoMarketCap").innerText = `Market Cap: ${result.marketCap}`;
        document.getElementById("cryptoVolume24h").innerText = `Volume (24h): ${result.volume24h}`;
        document.getElementById("cryptoPriceChange24h").innerText = `Price Change (24h): ${result.priceChangePercentage24h}%`;
        document.getElementById("cryptoHigh24h").innerText = `High (24h): ${result.high24h}`;
        document.getElementById("cryptoLow24h").innerText = `Low (24h): ${result.low24h}`;
        document.getElementById("cryptoPriceChange7d").innerText = `Price Change (7d): ${result.priceChangePercentage7d}%`;
        document.getElementById("cryptoTotalSupply").innerText = `Total Supply: ${result.totalSupply}`;
        document.getElementById("cryptoMaxSupply").innerText = `Max Supply: ${result.maxSupply}`;

    } else {
        alert("Crypto name is incorrect");
    }


});


async function saveSearchHistoryToDb(result) {

    await fetch("/Search/SaveSearchHistory", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(result)

    });
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
            .catch((error) => console.error('Ошибка: restoreCryptoFromHistory function', error))
    });

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

document.getElementById("addCrypto").addEventListener("click", function (event) {

    //$.ajax({
    //    url: '/Search/AddCryptoToMain',  // Укажите правильный URL для вашего метода
    //    type: 'POST',
    //    data: { 'crypto': currentCrypto }
    //});

});



//async function fetchWithAuth(url, options) {
//    const token = localStorage.getItem('jwtToken'); // Извлекаем токен из хранилища

//    // Убедитесь, что токен существует, иначе обработайте отсутствие авторизации
//    if (!token) {
//        alert("You are not logged in or your session has expired.");
//        return null; // Возвращаем null или throw new Error("No token available.");
//    }

//    // Устанавливаем заголовок Authorization, если он уже не задан
//    options.headers = options.headers || {};
//    options.headers['Authorization'] = `Bearer ${token}`;

//    // Делаем запрос с установленным заголовком Authorization
//    const response = await fetch(url, options);
//    if (!response.ok) {
//        // Обработка HTTP ошибок
//        throw new Error(`HTTP error! status: ${response.status}`);
//    }

//    return response; // Возвращаем результат в формате JSON
//}
