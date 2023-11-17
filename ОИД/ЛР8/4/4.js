let numCount = parseInt(prompt("Введите количество чисел:"));
let numbersArray = []; 

for (let i = 0; i < numCount; i++) {
    let number = parseInt(prompt("Введите число " + (i + 1) + ":"));
    numbersArray.push(number);
}

let oddNumbers = []; 

for (let j = 0; j < numbersArray.length; j++) {
    if (numbersArray[j] % 2 !== 0) {
        oddNumbers.push(numbersArray[j]);
    }
}

alert("Нечетные числа: " + oddNumbers.join(", "));
