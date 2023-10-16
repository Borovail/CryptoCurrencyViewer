var selectedCrypto;
var data;


const pathToDeleteFunction = "/Home/DeleteSelectedCrypto";
const pathToUpdateFunction = "/Home/UpdateSelectedCrypto";


document.addEventListener("DOMContentLoaded", function () {

    var deleteButton = document.getElementById("delete-button");
    deleteButton.addEventListener("click", async function (event) {

        try {

            if (await appealToSharpScript(pathToDeleteFunction)) 
                deleteCrypto();
            
        } catch (error) {
            console.error('Error:', error);
        }

    });
});


document.addEventListener("DOMContentLoaded", function () {

    var updateButton = document.getElementById("update-button");
    updateButton.addEventListener("click", async function (event) {

        try {

            if (await appealToSharpScript(pathToUpdateFunction)) 
                updateCrypto();
            
        } catch (error) {
            console.error('Error:', error);
        }

    });
});


function deleteCrypto()
{
    document.getElementById(selectedCrypto).remove();
}

function updateCrypto() {
    var row = document.getElementById(selectedCrypto);

    row.querySelector(".price").innerText = data.updatedCrypto.CurrentPrice;
    row.querySelector(".marketCap").innerText = data.updatedCrypto.MarketCap;
}

async function appealToSharpScript(funcName) {
    selectedCrypto = document.querySelector('input[name="selectedCrypto"]:checked').value;

    try {

        const response = await fetch(funcName, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ selectedCrypto: selectedCrypto })});

        data = await response.json();

        if (data.success) return true;
        else alert("Something went wrong, perhaps you forgot to save the selected cryptocurrency");

    } catch (error) {
        console.error('Error:', error);
        return false;
    }
}






document.addEventListener("DOMContentLoaded", function () {
    const subscriptionButton = document.getElementById("subscriptionButton");
    const subscriptionForm = document.getElementById("subscriptionForm");
    const submitSubscription = document.getElementById("submitSubscription");

    let isSubscribed = false;

    subscriptionButton.addEventListener("click", function () {
        if (subscriptionForm.style.display === "none" || subscriptionForm.style.display === "") {
            subscriptionForm.style.display = "block";
            subscriptionButton.textContent = "Collapse";
        } else {
            subscriptionForm.style.display = "none";
            subscriptionButton.textContent = isSubscribed ? "Unsubscribe" : "Subscribe";
        }
    });

    submitSubscription.addEventListener("click", function () {
        const name = document.getElementById("Name").value;
        const email = document.getElementById("Email").value;

        fetch('/Home/ManageSubscription', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Name: name, Email: email, Action: isSubscribed ? "unsubscribe" : "subscribe" })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    isSubscribed = !isSubscribed;
                    alert(isSubscribed ? "Congratulations, you are subscribed! 😊" : "You have successfully unsubscribed 😊");
                    subscriptionForm.style.display = "none";
                    subscriptionButton.textContent = isSubscribed ? "Unsubscribe" : "Subscribe";
                    submitSubscription.textContent = isSubscribed ? "Unsubscribe" : "Subscribe";
                } else {
                    alert("Something went wrong 😢");
                }
            });
    });
});
