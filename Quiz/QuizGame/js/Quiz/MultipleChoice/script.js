function randomIntFromInterval(min, max) { 
  return Math.floor(Math.random() * (max - min + 1) + min)
}
var items = [];
fetch("http://localhost:5049/api/Questions")
  .then(response=>{
    return response.json();
  })
  .then(data=>{
    data = data.sort(() => Math.random() - .7);
    for(let i =0; i<5;i++){
      var q = data[i];
      var randomAuthorName = randomIntFromInterval(0, 2);
      var question = {};
      if(randomAuthorName==0){
        question = {
          question: `Who said it ? \n"${q.questionText}" ?`,
          answers:[
            {text: q.option1, correct: true},
            {text: q.option2, correct: false},
            {text: q.option3, correct: false}
          ]
        }
      }
      else if(randomAuthorName==1){
          question = {
            question: `Who said it ? \n"${q.questionText}" ?`,
            answers: [
              {text: q.option2, correct: false},
              {text: q.option1, correct: true},
              {text: q.option3, correct: false}
            ]
          }
        }
      else{
        question = {
          question: `Who said it ? \n"${q.questionText}" ?`,
          answers: [
            {text: q.option3, correct: false},
            {text: q.option2, correct: false},
            {text: q.option1, correct: true}
          ]
        }
      }
      items.push(question); 
    }});
fetch;
const startButton = document.getElementById('start-btn');
const nextButton = document.getElementById('next-btn');
const questionContainerElement = document.getElementById('question-container');
const questionElement = document.getElementById('question');
const answerButtonsElement = document.getElementById('answer-buttons');

let shuffledQuestions, currentQuestionIndex;

startButton.addEventListener('click', startGame);

nextButton.addEventListener('click', () => {
  currentQuestionIndex++
  setNextQuestion()
});
var spn = document.getElementById('comment');
spn.classList.add("hide");
function startGame() {

  startButton.classList.add('hide')
  shuffledQuestions = questions;
  currentQuestionIndex = 0
  questionContainerElement.classList.remove('hide')
  setNextQuestion()
}

function setNextQuestion() {
  resetState()
  showQuestion(shuffledQuestions[currentQuestionIndex])
}

function showQuestion(question) {
  questionElement.innerText = question.question
  question.answers.forEach(answer => {
    const button = document.createElement('button')
    button.innerText = answer.text
    button.classList.add('btn')
    if (answer.correct) {
      button.dataset.correct = answer.correct
    }
    button.addEventListener('click', selectAnswer)
    answerButtonsElement.appendChild(button)
  })
}

function resetState() {
  var spn = document.getElementById('comment');
  spn.classList.add("hide");
  clearStatusClass(document.body)
  nextButton.classList.add('hide')
  while (answerButtonsElement.firstChild) {
    answerButtonsElement.removeChild(answerButtonsElement.firstChild)
  }
}
var index =0;
function selectAnswer(e) {
  const selectedButton = e.target
  const correct = selectedButton.dataset.correct
  var correctAnswerIndex = questions[index].answers.findIndex(x=>x.correct==true);
  var correctAnswer = questions[index].answers[correctAnswerIndex].text;
  if(correct){ 
    var spn = document.getElementById('comment');
    spn.innerHTML=`<strong>You are right! </strong>, The correct answer is : ${correctAnswer}`;
    spn.style.color="green";
    spn.classList.remove('hide');
  }
  else{
    var spn = document.getElementById('comment');
    spn.innerHTML=`<strong>You are wrong! </strong>, The correct answer is : ${correctAnswer}`;
    spn.style.color="red";
    spn.classList.remove('hide');
  }
  index++;
  setStatusClass(selectedButton,selectedButton.dataset.correct)
  if (shuffledQuestions.length > currentQuestionIndex + 1) {
    nextButton.classList.remove('hide')
  } else {
    startButton.innerText = 'Finish'
    startButton.style.backgroundColor=`green`;
    startButton.classList.remove('hide');
    startButton.addEventListener("click",()=>{
      window.location.href="/dashBoard.html";
    });

  }
}

function setStatusClass(element, correct) {
  clearStatusClass(element)
  if (correct) {
    element.classList.add('correct');
    
  } else {
    element.classList.add('wrong');
  }
}

function clearStatusClass(element) {
  element.classList.remove('correct')
  element.classList.remove('wrong')
}
var questions = items;