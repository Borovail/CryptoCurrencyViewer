
////sing out user  and clear localstorage  
function signOut() {
    // Удаление токена из localStorage
    localStorage.removeItem('jwtToken');

    // Обновление интерфейса
    const signOutLink = document.getElementById('signOutLink');
    const authorizationLinks = document.getElementsByClassName('authorization');

    if (signOutLink) signOutLink.style.display = 'none';
    Array.from(authorizationLinks).forEach(link => link.style.display = 'block');

    // Перенаправление на страницу входа
    window.location.href = '/Home/Index';
}



document.addEventListener('DOMContentLoaded', function () {

    const jwtToken = localStorage.getItem('jwtToken');

    const signOutLink = document.getElementById('signOutLink');
    const authorizationLinks = document.getElementsByClassName('authorization');

    // Показать или скрыть ссылки в зависимости от наличия токена
    if (jwtToken) {
        // Если токен существует, показать ссылку выхода и скрыть остальные
        if (signOutLink) signOutLink.style.display = 'block';
        Array.from(authorizationLinks).forEach(link => link.style.display = 'none');
    } else {
        // Если токена нет, скрыть ссылку выхода и показать остальные
        if (signOutLink) signOutLink.style.display = 'none';
        Array.from(authorizationLinks).forEach(link => link.style.display = 'block');
    }
});
