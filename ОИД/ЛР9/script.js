// Answers:
// 1. а
// 2. а в г
// 3. б
// 4. 2
// 5. б
// 6. 5
// 7. б г 
// 8. в
// 9. 55 
// 10. да

submitBtn = document.getElementById("submitBtn").addEventListener("click", (e) => {
    e.preventDefault();
    
    let userScore = 0;
    let maxScore = 0;

    // Поиск максимального количества баллов
    document.querySelector('.quizForm').querySelectorAll("input").forEach((element) => {
        maxScore += parseInt(element.getAttribute("data-true"));
    });

    // Проверка вопросов с radio
    let radioQuestions = document.querySelectorAll('input[type=radio]:checked');
    radioQuestions.forEach((element) => {
        userScore += parseInt(element.getAttribute("data-true"));
    })
    
    // Проверка вопросов с checkbox
    let checkboxQuestions = document.querySelectorAll('input[type=checkbox]:checked');
    checkboxQuestions.forEach((element) => {
        userScore += parseInt(element.getAttribute("data-true"));
    })
    
    // Проверка вопросов с text
    let textQuestions = document.querySelectorAll('input[type=text]');
    textQuestions.forEach((element) => {
        if (element.getAttribute("data-ans") == element.value.trim().toLowerCase()) {
            userScore += parseInt(element.getAttribute("data-true"));            
        }
    })
    
    alert("Вы набрали: " + userScore + "/" + maxScore + "!");
})