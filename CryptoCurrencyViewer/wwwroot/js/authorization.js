document.addEventListener('DOMContentLoaded', function () {
   /*  Обработчик для формы регистрации*/
    document.getElementById('registerSubmitBtn')?.addEventListener('click', function () {

        if (document.getElementById('confirmPassword').value !== document.getElementById('password').value) {
            alert("Password does not match");

            return;
        }

        // Собираем данные регистрации
        var registrationData = {
            name: document.getElementById('firstName').value,
            surname: document.getElementById('lastName').value,
            email: document.getElementById('registrationEmail').value,
            password: document.getElementById('password').value,
            role: "role"
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





////try  to add user to db   by calling a csharp script
////if ok   notify   success   and redirect to main page  if not ok   notify  not succes
function registerUser(data) {
    fetch("/Authorization/RegisterUser", {
        method: "POST",
        headers: {
            'Content-type': "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                alert("Successful registration!");
                window.location.href = '/Authorization/Login'; // Успешная регистрация
            } else {
                return response.json(); // Если ответ не 'ok', предполагается, что сервер вернул ошибки валидации в JSON
            }
        })
        .then(responseData => {
            if (responseData && responseData.errors) {
                // Показываем ошибки валидации, если они есть
                let errorMessage = "";
                for (const [key, value] of Object.entries(responseData.errors)) {
                    errorMessage += `${key}: ${value.join(", ")}\n`; // Соединяем все ошибки в одну строку
                }
                alert(`Registration failed: \n${errorMessage}`); // Показываем ошибки пользователю
            }
        })
        .catch(error => {
            // Отображаем ошибку, полученную от сервера или сетевую ошибку
            console.error('Error:', error);
        });
}





////try  to  login user  by searching  his email in db  and after if password matchs  returns  ok  else   unautchorized
////all checks in  csharp  here    proccesing response

/////if  all data ok set token   and redirect to main page
function loginUser(data) {
    fetch("/Authorization/LoginUser", {
        method: "POST",
        headers: {
            'Content-Type': "application/json"
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                // Обработка неудачного ответа от сервера
                return response.json().then(err => Promise.reject(err.message));
            }
        })
        .then(data => {
            localStorage.setItem("jwtToken", data.token); // Предполагается, что токен действительно возвращается в ответе
            window.location.href = '/Home/Index'; // Перенаправление на домашнюю страницу
        })
        .catch(error => {
            // Теперь error будет содержать сообщение, полученное от сервера
            alert('Error: ' + error); // Показываем ошибку пользователю
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
