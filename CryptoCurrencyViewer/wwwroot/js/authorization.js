document.addEventListener('DOMContentLoaded', function () {
   /*  ���������� ��� ����� �����������*/
    document.getElementById('registerSubmitBtn')?.addEventListener('click', function () {

        // �������� ������ �����������
        var registrationData = {
            firstName: document.getElementById('firstName').value,
            lastName: document.getElementById('lastName').value,
            email: document.getElementById('registrationEmail').value,
            password: document.getElementById('password').value,
            confirmPassword: document.getElementById('confirmPassword').value
        };

        // ���������� ������ �����������
        registerUser(registrationData);
    });
});

    document.addEventListener('DOMContentLoaded', function () {

    // ���������� ��� ����� �����
        document.getElementById('loginSubmitBtn')?.addEventListener('click', function (event) {

        // �������� ������ �����
        var loginData = {
            email: document.getElementById('loginEmail').value,
            password: document.getElementById('loginPassword').value,
            };

        // ���������� ������ �����
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
            console.error('Error: ', error); // ��������� ������ � ������ ���������� ������� ��� ������� �������
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

            localStorage.setItem("jwtToken", data.token); // ��������������, ��� ����� ������������� ������������ � ������
            // �������� ��������
            window.location.reload();

        })
        .catch(error => {
            console.error('Error: ', error); // ��������� ������ � ������ ���������� ������� ��� ������� �������
        });
}



async function fetchWithAuth(url, options) {
    const token = localStorage.getItem('jwtToken'); // ��������� ����� �� ���������

    // ���������, ��� ����� ����������, ����� ����������� ���������� �����������
    if (!token) {
        alert("You are not logged in or your session has expired.");
        return null; // ���������� null ��� throw new Error("No token available.");
    }

    // ������������� ��������� Authorization, ���� �� ��� �� �����
    options.headers = options.headers || {};
    options.headers['Authorization'] = `Bearer ${token}`;

    // ������ ������ � ������������� ���������� Authorization
    const response = await fetch(url, options);
    if (!response.ok) {
        // ��������� HTTP ������
        throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json(); // ���������� ��������� � ������� JSON
}
