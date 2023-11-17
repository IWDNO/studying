number = null;

document.getElementById('button1').addEventListener('click', function() {
    let userInput = prompt('Введите число: ');
    if (userInput === null || userInput === "") return;
    number = Math.abs(userInput);
});

document.getElementById('button2').addEventListener('click', function() {
    if (number === null) {
        alert('wrong number!');
        return;
    };

    for (let i = number; i >= 0; i--) {
        if (i === 0) {
            alert("Finish");
        } else {
            alert(i);
        }
    };
});
