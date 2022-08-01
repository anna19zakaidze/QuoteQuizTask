const btn = document.querySelector('#mode');        
const radioButtons = document.querySelectorAll('input[name="quizMode"]');
var form = document.querySelector(".modeForm");
var message = document.querySelector("#message");
btn.addEventListener("click", () => {
    let selectedMode;
    for (const radioButton of radioButtons) {
            if (radioButton.checked) {
                    selectedMode = radioButton.value;
                    break;
                }
            }
    if(radioButtons[0].checked){
        form.action="/js/Quiz/Binary/index.html";
        this.form.submit();
    }
    else if(radioButtons[1].checked){
        form.action="/js/Quiz/MultipleChoice/index.html";
        this.form.submit();
    }
    else {
        message.innerText = selectedSize ? `You selected ${selectedSize}` : `You haven't selected any size`;
    }
});
