document.addEventListener('DOMContentLoaded', function () {
    const burgerMenu = document.getElementById('burger-menu');
    const navList = document.querySelector('.nav_list');

    burgerMenu.addEventListener('click', function () {
        navList.classList.toggle('show');
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const header = document.querySelector('.header');
    const offset = 100; // Высота вашего header
    

    window.addEventListener('scroll', function () {
        if (window.scrollY > offset && !header.classList.contains('fixed')) {
            header.classList.add('hidden');
            header.classList.add('fixed');
        } else if (window.scrollY <= offset) {
            header.classList.remove('hidden');
            header.classList.remove('fixed');
        }
    });
});
