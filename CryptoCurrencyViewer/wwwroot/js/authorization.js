document.addEventListener('DOMContentLoaded', function () {
   /*  Обработчик для формы регистрации*/
    document.getElementById('registerSubmitBtn')?.addEventListener('click', function () {

        // Собираем данные регистрации
        var registrationData = {
            firstName: document.getElementById('firstName').value,
            lastName: document.getElementById('lastName').value,
            email: document.getElementById('registrationEmail').value,
            password: document.getElementById('password').value,
            confirmPassword: document.getElementById('confirmPassword').value
        };

        // Отправляем данные регистрации
        registerUser(registrationData);
    });
});

    document.addEventListener('DOMContentLoaded', function () {

    // Обработчик для формы входа
        document.getElementById('loginSubmitBtn')?.addEventListener('click', function (event) {

        // Собираем данные входа
        var loginData = {
            email: document.getElementById('loginEmail').value,
            password: document.getElementById('loginPassword').value,
            };

        // Отправляем данные входа
          loginUser(loginData);
    });
});


 function registerUser(data) {
    //...check if all data is okay
    fetch("/Authorization/RegisterUser", {
        method: "POST",
        headers: {
            'Content-type': "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {

                alert("Succesfull registration!");

                window.location.reload();

            }
            else
                Promise.reject('Authorization fail')
            })
 
        .catch(error => {
            console.error('Error: ', error); // Обработка ошибок в случае отклонения промиса или сетевых проблем
        });
  
}



 function loginUser(data) {

    fetch("/Authorization/LoginUser", {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => response.ok ? response.json() : Promise.reject('Authorization fail'))
        .then(data => {

            localStorage.setItem("jwtToken", data.token); // Предполагается, что токен действительно возвращается в ответе
            // Обновить страницу
            window.location.reload();

        })
        .catch(error => {
            console.error('Error: ', error); // Обработка ошибок в случае отклонения промиса или сетевых проблем
        });
}



async function fetchWithAuth(url, options) {
    const token = localStorage.getItem('jwtToken'); // Извлекаем токен из хранилища

    // Убедитесь, что токен существует, иначе обработайте отсутствие авторизации
    if (!token) {
        alert("You are not logged in or your session has expired.");
        return null; // Возвращаем null или throw new Error("No token available.");
    }

    // Устанавливаем заголовок Authorization, если он уже не задан
    options.headers = options.headers || {};
    options.headers['Authorization'] = `Bearer ${token}`;

    // Делаем запрос с установленным заголовком Authorization
    const response = await fetch(url, options);
    if (!response.ok) {
        // Обработка HTTP ошибок
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json(); // Возвращаем результат в формате JSON
}
