// Объявление переменных и констант
const pathToDeleteFunction = "/Home/DeleteSelectedCrypto";
const pathToUpdateFunction = "/Home/UpdateSelectedCrypto";
let selectedCrypto;
let data;

// Обработчик события загрузки DOM
document.addEventListener("DOMContentLoaded", function () {

    // Управление подпиской
    initSubscriptionForm();

    // Удаление криптовалюты
    const deleteButton = document.getElementById("delete-button");
    deleteButton.addEventListener("click", async function () {
        if (await appealToSharpScript(pathToDeleteFunction)) {
            deleteCrypto();
        }
    });

    // Обновление криптовалюты
    const updateButton = document.getElementById("update-button");
    updateButton.addEventListener("click", async function () {
        if (await appealToSharpScript(pathToUpdateFunction)) {
            updateCrypto();
        }
    });
});

function initSubscriptionForm() {
    const subscriptionButton = document.getElementById("subscriptionButton");
    const subscriptionForm = document.getElementById("subscriptionForm");
    const submitSubscription = document.getElementById("submitSubscription");
    let isSubscribed = false;

    subscriptionButton.addEventListener("click", function () {
        toggleSubscriptionForm(subscriptionForm, subscriptionButton, isSubscribed);
    });

    submitSubscription.addEventListener("click", function () {
        manageSubscription(isSubscribed);
    });
}

function toggleSubscriptionForm(form, button, isSubscribed) {
    if (form.style.display === "none" || form.style.display === "") {
        form.style.display = "block";
        button.textContent = "Collapse";
    } else {
        form.style.display = "none";
        button.textContent = isSubscribed ? "Unsubscribe" : "Subscribe";
    }
}

async function manageSubscription(isSubscribed) {
    const name = document.getElementById("Name").value;
    const email = document.getElementById("Email").value;

    // Здесь ваш код для подписки/отписки
}

async function appealToSharpScript(funcName) {
    const radio = document.querySelector('input[name="selectedCrypto"]:checked');

    if (!radio) {
        alert("Please select a cryptocurrency first.");
        return false;
    }

    selectedCrypto = radio.value;

    try {
        const response = await fetch(funcName, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({selectedCrypto: selectedCrypto })
        });

        data = await response.json();

        if (data.success) {
            return true;
        } else {
            alert("Something went wrong. Perhaps you forgot to save the selected cryptocurrency.");
            return false;
        }
    } catch (error) {
        alert('An error occurred: ' + error);
        return false;
    }
}

function deleteCrypto() {
    const element = document.getElementById(selectedCrypto);
    if (element) element.remove();
}

function updateCrypto() {
    const row = document.getElementById(selectedCrypto);

    if (!row) return;

    // Предполагается, что у вас есть элементы с классами 'price' и 'marketCap' в строке.
    const priceElement = row.querySelector(".price");
    const marketCapElement = row.querySelector(".marketCap");

    if (priceElement) priceElement.innerText = data.updatedCrypto.currentPrice+" USD";
    if (marketCapElement) marketCapElement.innerText = data.updatedCrypto.marketCap +" USD";
}




function openSearchPage(cryptoName) {
    window.location.href = `/Search/ExtendedInfo?selectedCrypto=${cryptoName}`;
}











document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("cryptoId");
    const searchButton = document.getElementById("searchButton");
    const cryptoTable = document.getElementById("cryptoTable");
    const tbody = cryptoTable.querySelector("tbody");
    const rows = Array.from(tbody.querySelectorAll("tr"));

    let lastQuery = "";

    searchInput.addEventListener("input", function () {
        const query = this.value.trim().toLowerCase();

        if (query === lastQuery) return;

        lastQuery = query;

        // Очистка и восстановление таблицы
        rows.forEach(row => tbody.appendChild(row));

        // Фильтрация и подсветка строк
        rows.forEach(row => {
            const nameCell = row.querySelector(".crypto-name");
            const name = nameCell.textContent.trim().toLowerCase();
            if (name.includes(query)) {
                nameCell.innerHTML = highlightText(name, query); // подсветить текст
            } else {
                nameCell.innerHTML = name;
            }
        });

        // Перемещение совпадающих строк вверх
        const matchingRows = rows.filter(row => {
            const nameCell = row.querySelector(".crypto-name");
            const name = nameCell.textContent.trim().toLowerCase();
            return name.includes(query);
        });

        matchingRows.forEach(row => tbody.insertBefore(row, tbody.firstChild));
    });

    searchButton.addEventListener("click", function (event) {

        event.preventDefault();

        const query = searchInput.value.trim().toLowerCase();

        rows.forEach(row => {
            const nameCell = row.querySelector(".crypto-name");
            const name = nameCell.textContent.trim().toLowerCase();
            row.style.display = name.includes(query) ? "" : "none";
        });
    });

    function highlightText(text, query) {
        const regex = new RegExp(`(${query})`, "gi");
        return text.replace(regex, "<span class='highlight'>$1</span>");
    }

    rows.forEach(row => {
        row.addEventListener("click", function () {
            const nameCell = this.querySelector(".crypto-name");
            const name = nameCell.textContent.trim();
            searchInput.value = name;
        });
    });
});
