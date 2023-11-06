document.addEventListener('DOMContentLoaded', function () {
   /*  ���������� ��� ����� �����������*/
    document.getElementById('registerSubmitBtn')?.addEventListener('click', function () {

        if (document.getElementById('confirmPassword').value !== document.getElementById('password').value) {
            alert("Password does not match");

            return;
        }

        // �������� ������ �����������
        var registrationData = {
            name: document.getElementById('firstName').value,
            surname: document.getElementById('lastName').value,
            email: document.getElementById('registrationEmail').value,
            password: document.getElementById('password').value,
            role: "role"
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
                window.location.href = '/Authorization/Login'; // �������� �����������
            } else {
                return response.json(); // ���� ����� �� 'ok', ��������������, ��� ������ ������ ������ ��������� � JSON
            }
        })
        .then(responseData => {
            if (responseData && responseData.errors) {
                // ���������� ������ ���������, ���� ��� ����
                let errorMessage = "";
                for (const [key, value] of Object.entries(responseData.errors)) {
                    errorMessage += `${key}: ${value.join(", ")}\n`; // ��������� ��� ������ � ���� ������
                }
                alert(`Registration failed: \n${errorMessage}`); // ���������� ������ ������������
            }
        })
        .catch(error => {
            // ���������� ������, ���������� �� ������� ��� ������� ������
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
                // ��������� ���������� ������ �� �������
                return response.json().then(err => Promise.reject(err.message));
            }
        })
        .then(data => {
            localStorage.setItem("jwtToken", data.token); // ��������������, ��� ����� ������������� ������������ � ������
            window.location.href = '/Home/Index'; // ��������������� �� �������� ��������
        })
        .catch(error => {
            // ������ error ����� ��������� ���������, ���������� �� �������
            alert('Error: ' + error); // ���������� ������ ������������
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
