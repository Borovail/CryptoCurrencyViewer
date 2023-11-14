// Объявление переменных и констант
const pathToDeleteFunction = "/Home/DeleteSelectedCrypto";
const pathToUpdateFunction = "/Home/UpdateSelectedCrypto";
let selectedCrypto, toket;
var responseCrypto;

// Обработчик события загрузки DOM
document.addEventListener("DOMContentLoaded",async function () {

    // Удаление криптовалюты
    const deleteButton = document.getElementById("delete-button");
    deleteButton.addEventListener("click", async function () {
        if (!checkCondotions()) return;

        Swal.fire({
            title: "Are you want to delete "+selectedCrypto+" from favorites?",
            showDenyButton: true,
            confirmButtonText: "Yes",
            denyButtonText: `Don't`
        }).then(async (result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                if (await appealToSharpScript(pathToDeleteFunction)) {

                deleteCrypto();
                Swal.fire("Deleted!", "", "success");

                }
            } 
        });



    });




    // Обновление криптовалюты
    const updateButton = document.getElementById("update-button");
    updateButton.addEventListener("click", async function () {
        if (!checkCondotions()) return;
        if (await appealToSharpScript(pathToUpdateFunction)) {


            updateCrypto();

            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Crypto succesfully updated",
                showConfirmButton: false,
                timer: 1500
            });

        }
       
     
      
    });
});


function checkCondotions() {
    const radio = document.querySelector('input[name="selectedCrypto"]:checked');
     token = getToket();

    if (!radio) {
        Swal.fire({
            title: "Please select a cryptocurrency first.",
            position: "top",
            timer:2000
        });
        return false;
    }

    if (!token) {
        return false;
    }

    selectedCrypto = radio.value;
    return true;
}

async function appealToSharpScript(funcName) {


    try {
        // Вызываем fetch и обрабатываем ответ
        const response = await fetch(funcName, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify(selectedCrypto)
        });

        if (response.ok) { // Проверяем, что ответ успешный
            responseCrypto = await response.json();
            return true;
        } else {
            // Обработка HTTP-ошибок, например, когда response.ok === false
            const errorText = await response.text();
            return false;
        }
    } catch (error) {
        // Ошибка связанная с сетевым запросом или обработкой данных
        alert('An error occurred: ' + error.message); // Убедитесь, что используете error.message
        return false; // Явно возвращаем false в случае ошибки
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

    if (priceElement) priceElement.innerText = responseCrypto.currentPrice + " USD";
    if (marketCapElement) marketCapElement.innerText = responseCrypto.marketCap + " USD";

    row.classList.add('updated-row-animation');
    // Удалите класс анимации после ее выполнения, если он не удаляется автоматически
    row.addEventListener('animationend', () => {
        row.classList.remove('updated-row-animation');
    });
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
        let debounceTimeout = null;
        const debounceDelay = 300; // Задержка в мс

            clearTimeout(debounceTimeout);
            debounceTimeout = setTimeout(() => {

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

               

            }, debounceDelay);
    
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
        if (query.length > 0) {
            const regex = new RegExp(`(${query})`, "gi");
            return text.replace(regex, "<span class='highlight'>$1</span>");
        }
        return text; // Возвращайте исходный текст, если запрос пустой
    }

    rows.forEach(row => {
        row.addEventListener("click", function () {
            const nameCell = this.querySelector(".crypto-name");
            const name = nameCell.textContent.trim();
            searchInput.value = name;
        });

    });




});



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




