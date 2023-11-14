
var currentCrypto;
document.addEventListener("DOMContentLoaded", async function (event) {
    var token = getToket(); // Исправлено на правильное имя функции

    if (!token) {
        return;
    }

    await fetch('/Search/GetSearchHistory', {
        method: "GET",
        headers: {
            'Authorization': 'Bearer ' + token
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            data.forEach(item => {
                // Используйте литерал объекта для создания объекта, а не 'new'
                saveSearchHistoryLocally({ name: item.name, symbol: item.defaultCryptoModel.symbol, searchTime: item.defaultCryptoModel.searchTime });
            });
        })
        .catch((error) => console.error('Ошибка:', error));
});



document.getElementById("searchButton").addEventListener("click", async function (event) {



    var token = localStorage.getItem("jwtToken");

    if (!token) {
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
    }).catch((error) => console.log('Error:', error));



    if (response.ok) {
        const result = await response.json();

        if (result == null) {

            Swal.fire({
                title: "Sorry, it looks like there are not crypto that match your request",
                position: "top",
                timer : 3000
                });


        }

        currentCrypto = result;

      await  saveSearchHistoryToDb(result.name);
      await  saveSearchHistoryLocally(result);


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
        Swal.fire({
            title: "Sorry, it looks like there are not crypto that match your request",
            position: "top",
            timer: 3000
        });
    }


});



async function markFavorite(currentCrypto) {
    var token = localStorage.getItem("jwtToken");

    if (!token) {
        return;
    }

    // Обратите внимание, что .then() должен следовать сразу за вызовом fetch, а не быть внутри body
    await fetch("/Search/MarkAsFavourite", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(currentCrypto) // Здесь заканчивается body
    })

        .then(() => {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: currentCrypto.name + " successfully added to your favorites list",
                showConfirmButton: false,
                timer: 3000
            });
        })
        .catch((error) => {
            console.log('Error:', error);
            // Показать сообщение об ошибке пользователю, если это уместно
        });
}





function openExchangePage(cryptoName) {

    cryptoName = currentCrypto.name;

    window.location.href = `/Exchanges/ExchangeFrom?cryptoName=${cryptoName}`;
}



async function saveSearchHistoryToDb(result) {

    var token = getToket();

    if (token == null) {
        return;
    }

    await fetch("/Search/SaveSearchHistory", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
         body: JSON.stringify(result) // Добавляем result в тело запроса
            
    }).catch((error) => console.log('Error: Unable to save history'+ error));
}


function saveSearchHistoryLocally(result) {
    const ul = document.getElementById("search-history");
    const li = document.createElement("li");
    li.textContent = `${result.name} - ${result.symbol}  ||  ${result?.searchTime}`;
    li.className = "search-history-item list-group-item";
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
        Swal.fire({
            title: "You are not logged in or your session has expired.",
            position: "top"
        });
        return null; // Возвращаем null или throw new Error("No token available.");
    }

     return token;
}


