// Переключение категорий
const tradeIn = document.getElementById('tradeIn');
const financialServices = document.getElementById('financialServices');
const serviceServices = document.getElementById('serviceServices');
const autoParts = document.getElementById('autoParts');

const serviceText = document.getElementById('categoryText');
const serviceImge = document.getElementById('serviceImg');

tradeIn.addEventListener('click', () => {
    serviceText.innerHTML = '<b>Trade-in:</b><br><br>Гранд-Мотор продает новые автомобили и с пробегом, отечественные машины и иномарки по системе Trade-in во Владимире и Владимирской области. Вам не нужно встречаться с массой возможных покупателей и подвергать риску себя и свои деньги. Наши специалисты обеспечат высокий уровень обслуживания, полную безопасность и прозрачные условия сделки.';
    serviceImge.src = "./img/services/tradein.png"
});

financialServices.addEventListener('click', () => {
    serviceText.innerHTML = '<b>Финансовые услуги:</b><br><br>Группа компаний «Гранд-Мотор» уже много лет продает автомобили во Владимирской области. Наша цель — найти оптимальное решение для каждого клиента. Мы предлагаем пакет финансовых услуг на приобретение автомобиля.';
    serviceImge.src = "./img/services/finance.png"
});

serviceServices.addEventListener('click', () => {
    serviceText.innerHTML = '<b>Сервис:</b><br><br>Гранд-Мотор занимается техническим, гарантийным и постгарантийным обслуживанием авто. Мы используем современное оборудование, оперативно проводим диагностику и ремонт любой сложности.';
    serviceImge.src = "./img/services/service.png"
});

autoParts.addEventListener('click', () => {
    serviceText.innerHTML = '<b>Автозапчасти:</b><br><br>Гранд-Мотор занимается продажей запчастей, автохимии, расходных материалов, аксессуаров для автомобилей. Вы можете заказать нужные запчасти онлайн или приехать в магазин. Также мы предоставляем сезонные скидки и гарантируем быструю доставку товаров.';
    serviceImge.src = "./img/services/parts.png"
});


// Переключение фото
const images = ["./img/lada.jpg", "./img/KIA.jpeg", "./img/uni-v.jpeg"];
let currentIndex = 0;

function changeImage(offset) {
    currentIndex = (currentIndex + offset + images.length) % images.length;
    // const image = document.querySelector('.image');
    const content = document.getElementById("description");
    const imageBlock =  document.querySelector('.photo-container');

    setTimeout(() => {
        imageBlock.style.background = "url(" + images[currentIndex] + ")";
        imageBlock.style.backgroundSize = 'cover';
        imageBlock.style.backgroundPosition = 'center';
    }, 100); // Задержка, чтобы дать время для плавного перехода
    setTimeout(() => {
        content.innerHTML = getContent(currentIndex);
    }, 300); // Задержка, чтобы дать время для плавного перехода
}

function getContent(index) {
    // Здесь вы можете определить текст и другое содержимое для каждой фотографии
    // Например, с использованием массива или объекта
    const contentArray = [
        { title: 'KIA SORENTO', text: 'Играя главнцю роль' },
        { title: 'LADA GRANTA', text: 'Держит слово'},
        { title: 'ВОПЛОЩЕНИЕ ВОВЕРШЕНСТВА UNI-V', text: 'Эстетика в динамике' },
    ];

    return `<div class="content">
                <h2 id="blockTitle">${contentArray[index].title}</h2>
                <p id="blockText">${contentArray[index].text}</p>
            </div>
            <a href="#" class="button-text">Подробнее</a>`;
}


// Переключение новостей

const newsImages = ["./img/news/chengan.png", "./img/news/NIVA.png", "./img/news/UNI.png"];
let currentNewsIndex = 0;

function changeNews(offset) {
    currentNewsIndex = (currentNewsIndex + offset + newsImages.length) % newsImages.length;
    const newsImage = document.getElementById("newsImg");
    const newsText = document.getElementById("newsText");
    const ntc = document.getElementById("newsTextContainer");

    newsImage.style.opacity = 0;
    newsText.style.opacity = 0;
    ntc.style.background = "white";


    setTimeout(() => {
        newsImage.src = newsImages[currentNewsIndex];
        newsImage.style.opacity = 1;
        // Вам также нужно обновить текст новостей здесь
        // Например, с использованием массива или объекта
        newsText.innerHTML = getNewsContent(currentNewsIndex);
        newsText.style.opacity = 1;
        ntc.style.background = "#f8f8f8";
    }, 200);
}

function getNewsContent(index) {
    const newsContentArray = [
        'Changan Alsvin и его потрясающие характеристики',
        '“Путеводитель по раздаточной коробке: NIVA в деталях“',
        'UNI-K признан лучшим SUV-купе по версии National Auto Award.'
    ];

    return newsContentArray[index];
}


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


// 
document.addEventListener("DOMContentLoaded", function() {
    const categories = document.querySelectorAll('.categories li');
    
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

