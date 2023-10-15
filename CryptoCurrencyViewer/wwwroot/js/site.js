var action;
document.addEventListener("DOMContentLoaded", function () {
    // Находим все кнопки с классами "update-button" и "delete-button"
    document.querySelectorAll(".action-button").forEach(function (button) {
        button.addEventListener("click", function (event) {
            // Получаем выбранную криптовалюту и действие (обновить или удалить)
            var selectedCrypto = document.querySelector('input[name="selectedCrypto"]:checked').value;
            action = event.target.getAttribute("data-action");

            // Отправляем AJAX-запрос на сервер
            fetch('/Home/UpdateOrDeleteSelectedCrypto', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ selectedCrypto: selectedCrypto, action: action })
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        // Выполняем действие на клиенте (например, удаляем строку)
                        if (action === "delete") {
                            var row = document.getElementById(selectedCrypto);
                            row.remove();
                        }
                        if (action === "update") {
                            var row = document.getElementById(selectedCrypto);

                            row.querySelector(".price").innerText = data.updatedCrypto.CurrentPrice;
                            row.querySelector(".marketCap").innerText = data.updatedCrypto.MarketCap;
                        
                        }
                    } else {
                        alert("Что-то пошло не так.");
                    }
                });
        });
    });
});


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
