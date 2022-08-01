// import {saveUser} from "./saveUser.js";
class Login{
    constructor(form,fields){
        this.form = form;
        this.fields = fields;
        this.validateOnSubmit();
    }
    validateOnSubmit(){
        let self = this;

        this.form.addEventListener("submit",(e)=>{
            e.preventDefault();
            var error = 0;
        self.fields.forEach(field => {
            const input = document.querySelector(`#${field}`);
            if(self.validateFields(input)==false){
                error++;
            }
        });
        if(error == 0){
            console.log("success");
            var name = document.getElementById("username");
            var email = document.getElementById("email");
            // saveUser(name,email);

            localStorage.setItem("auth",1)
            this.form.submit();
        }
        });
    }

    validateFields(field){
        if(field.value.trim()==''){
            this.setStatus(
                field,
                `${field.previousElementSibling.innerText} cannot be blank`,
                "error"
            );
            return false;
        }
        else{
            if(field.type=="email"){

            }
        }
    }
    setStatus(field,message,status){
        const errorMessage = field.parentElement.querySelector(".error-message");
        if(status == "success"){
            if(errorMessage){
                errorMessage.innerText = "";
            }
            field.classList.add("input-error");
        }
        if(status == "error"){
            errorMessage.innerText = message;
            field.classList.add("input-error");
        }
    }
}

const form = document.querySelector(".loginForm");

if(form){
    const fields = ["username","email"];
    const validator = new Login(form, fields);
}