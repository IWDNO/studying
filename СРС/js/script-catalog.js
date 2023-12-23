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


document.addEventListener("DOMContentLoaded", function() {
    const categories = document.querySelectorAll('.sort a');
    console.log(categories);
    
    categories.forEach(function(category) {
        category.addEventListener('click', function() {
            categories.forEach(function(c) {
                c.classList.remove('active');
            });
            
            this.classList.add('active');
        });
    });

    // Выбрать первый элемент по умолчанию
    categories[0].click();
});

function sortItems(sortBy) {
    var itemsContainer = document.querySelector('.catalog');
    var items = Array.from(document.querySelectorAll('.item'));

    items.sort(function (a, b) {
        var aValue, bValue;

        switch (sortBy) {
            case 'popularity':
                aValue = parseInt(a.getAttribute('data-popularity'));
                bValue = parseInt(b.getAttribute('data-popularity'));
                break;
            case 'price':
                aValue = parseFloat(a.getAttribute('data-price'));
                bValue = parseFloat(b.getAttribute('data-price'));
                break;
            case 'alphabetically':
                aValue = a.getAttribute('data-name').toLowerCase();
                bValue = b.getAttribute('data-name').toLowerCase();
                break;
        }

        // Сравнение строк
        if (aValue < bValue) return -1;
        if (aValue > bValue) return 1;
        return 0;
    });

    // Вставить отсортированные товары обратно в контейнер
    itemsContainer.innerHTML = '';
    items.forEach(function (item) {
        item.style.opacity = 0;
        itemsContainer.appendChild(item);
        setTimeout(() => {
            item.style.opacity = 1;
        }, 200)
    });

}