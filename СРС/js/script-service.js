var serviceBlocks = document.querySelectorAll('.service');

serviceBlocks.forEach(function(block) {
    block.addEventListener('click', function() {
        var url = this.getAttribute('data-url');
        if (url) {
            window.location.href = url;
        }
    });
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