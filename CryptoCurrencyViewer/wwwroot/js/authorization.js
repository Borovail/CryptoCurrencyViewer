// Event listener for DOM content loaded
document.addEventListener('DOMContentLoaded', async function () {

    /* Handler for the registration form submit action */
    document.getElementById('registerSubmitBtn')?.addEventListener('click', function () {
        // Check if the confirm password matches the password entered
        if (document.getElementById('confirmPassword').value !== document.getElementById('password').value) {
            // Display a warning modal if passwords do not match
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Passwords do not match. Please try again.'
            });
            return;
        }

        // Gather registration data from the form
        var registrationData = {
            name: document.getElementById('firstName').value,
            surname: document.getElementById('lastName').value,
            email: document.getElementById('registrationEmail').value,
            password: document.getElementById('password').value,
            role: "User" // Assuming default role as "User", replace with actual role if needed
        };

        // Invoke the function to register the user with the gathered data
        registerUser(registrationData);
    });

    /* Handler for the login form submit action */
    document.getElementById('loginSubmitBtn')?.addEventListener('click', function () {
        // Gather login data from the form
        var loginData = {
            email: document.getElementById('loginEmail').value,
            password: document.getElementById('loginPassword').value
        };

        // Invoke the function to log the user in with the gathered data
        loginUser(loginData);
    });
});

// Function to register user with data provided from the registration form
function registerUser(data) {
    fetch("/Authorization/RegisterUser", {
        method: "POST",
        headers: { 'Content-type': "application/json" },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (response.ok) {
                // Display success notification and redirect to login page after timer
                Swal.fire({
                    icon: 'success',
                    title: 'Registration Successful',
                    text: 'You will be redirected to the login page.',
                    showConfirmButton: false,
                    timer: 2500
                }).then(() => {
                    window.location.href = '/Authorization/Login'; // Redirect to login
                });
            } else {
                return response.json(); // Deserialize JSON response from the server
            }
        })
        .then(responseData => {
            if (responseData && responseData.errors) {
                // Display errors returned from server validation
                let errorMessage = Object.entries(responseData.errors).map(([key, value]) => {
                    return `${key}: ${value.join(", ")}`; // Format the errors into a string
                }).join("\n");
                // Display the formatted error message in a modal
                Swal.fire({
                    icon: 'error',
                    title: 'Registration Failed',
                    text: errorMessage,
                    showConfirmButton: true
                });
            }
        })
        .catch(error => {
            // Display any server or network error in a modal
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: `An error occurred: ${error}`
            });
        });
}

// Function to log user in with data provided from the login form
//// Attempt to log user in by verifying their credentials against the database
//// If credentials match, server responds with "ok" and provides a JWT token
//// Otherwise, the server responds with "unauthorized"
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
                return response.json(); // If login is successful, parse the JSON token returned
            } else {
                // If server response is not 'ok', handle the failed login attempt
                return response.json().then(err => Promise.reject(err.message));
            }
        })
        .then(data => {
            localStorage.setItem("jwtToken", data.token); // Store the JWT token in local storage

            // Display a success notification with a button to proceed
            return Swal.fire({
                icon: 'success',
                title: 'You logged in successfully!',
                confirmButtonText: 'Continue'
            });
        })
        .then(() => {
            // After the user clicks 'Continue', redirect them to the home page
            window.location.href = '/Home/Index';
        })
        .catch(error => {
            // Display an error notification if the login fails
            Swal.fire({
                icon: 'error',
                title: 'Login Failed',
                text: 'Error: ' + error
            });
        });
}
