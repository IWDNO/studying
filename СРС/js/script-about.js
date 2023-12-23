window.addEventListener('scroll', () => {
    let header = document.getElementById('navigation');
    let other = document.getElementById("other");
    const scrollPosition = window.scrollY;
    if (scrollPosition >= 467) {
        header.classList.add('fixed');
        other.style.paddingLeft = "25%";
        other.style.width = "125%";
    } else {
        header.classList.remove('fixed');
        other.style.paddingLeft = "0";
        other.style.width = "100%";
    }
});

// header static
window.addEventListener('scroll', () => {
    let header = document.querySelector('.header');
    const scrollPosition = window.scrollY;

    if (scrollPosition > 200) {
        header.classList.add('header_fixed');
        document.querySelector('body').style.paddingTop = "70px";
    } else {
        header.classList.remove('header_fixed');
        document.querySelector('body').style.paddingTop = "0px";
    }
});