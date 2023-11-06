
////sing out user  and clear localstorage  
function signOut() {

    Swal.fire({
        title: 'Are you sure?',
        text: "You wanna sign out",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, sign out!',
        cancelButtonText: 'No, stay signed!'
    }).then((result) => {
        if (result.isConfirmed) {
            // ������������ ����� "Yes"
            Swal.fire(
                'Bye!',
                'We will be waiting for you.',
                'success'
            )

            // �������� ������ �� localStorage
            localStorage.removeItem('jwtToken');

            // ���������� ����������
            const signOutLink = document.getElementById('signOutLink');
            const authorizationLinks = document.getElementsByClassName('authorization');

            if (signOutLink) signOutLink.style.display = 'none';
            Array.from(authorizationLinks).forEach(link => link.style.display = 'block');

            // ��������������� �� �������� �����
            window.location.href = '/Home/Index';


        } else if (result.dismiss === Swal.DismissReason.cancel) {
            // ������������ ����� "No"
            return;
        }
    });
   
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






