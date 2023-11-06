
////sing out user  and clear localstorage  
function signOut() {
    // �������� ������ �� localStorage
    localStorage.removeItem('jwtToken');

    // ���������� ����������
    const signOutLink = document.getElementById('signOutLink');
    const authorizationLinks = document.getElementsByClassName('authorization');

    if (signOutLink) signOutLink.style.display = 'none';
    Array.from(authorizationLinks).forEach(link => link.style.display = 'block');

    // ��������������� �� �������� �����
    window.location.href = '/Home/Index';
}



document.addEventListener('DOMContentLoaded', function () {

    const jwtToken = localStorage.getItem('jwtToken');

    const signOutLink = document.getElementById('signOutLink');
    const authorizationLinks = document.getElementsByClassName('authorization');

    // �������� ��� ������ ������ � ����������� �� ������� ������
    if (jwtToken) {
        // ���� ����� ����������, �������� ������ ������ � ������ ���������
        if (signOutLink) signOutLink.style.display = 'block';
        Array.from(authorizationLinks).forEach(link => link.style.display = 'none');
    } else {
        // ���� ������ ���, ������ ������ ������ � �������� ���������
        if (signOutLink) signOutLink.style.display = 'none';
        Array.from(authorizationLinks).forEach(link => link.style.display = 'block');
    }
});
