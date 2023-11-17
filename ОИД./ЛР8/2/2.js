document.getElementById('button').addEventListener('click', function() {
    let userInput = prompt("Введите число от 1 до 10: ");
    let number = parseInt(userInput);

    switch (number) {
        case 6:
        case 7:
        case 8:
        case 10:
            alert('Близко');
            break;
        case 9:
            alert('Верно');
            break;
        default:
            alert('Неверно')
    }
});
