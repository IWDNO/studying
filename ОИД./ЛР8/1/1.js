let array = [];

while (true) {
    let userInput = prompt("Введите значение (или нажмите 'Отмена' для завершения):");

    if (userInput === null) {
        break;
    }
    array.push(userInput);
}

alert("Ваш массив: " + array);
