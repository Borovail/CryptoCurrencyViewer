
document.getElementById("searchbutton").addEventListener("click" ,async function (event) {

   var inputField= document.getElementById("cryptoId");

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
        const result =await response.json();

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