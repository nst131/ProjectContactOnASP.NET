let generateError = function (text) {
    let error = document.createElement('div')
    error.className = 'error'
    error.innerHTML = text
    return error
}

let removeValidation = function () {
    let form = document.querySelector('.formWithValidation')
    let errors = form.querySelectorAll('.error')

    for (let i = 0; i < errors.length; i++) {
        errors[i].remove()
    }
}

let checkFieldsForEmptiness = function () {
    let form = document.querySelector('.formWithValidation')
    let fields = form.querySelectorAll('.field')

    for (let i = 0; i < fields.length; i++) {
        if (!fields[i].value) {
            let error = generateError('Field is required');
            fields[i].parentElement.querySelector('.failing').append(error);
            event.preventDefault();
        }
    }
}

let checkPhoneForRegex = function () {
    let form = document.querySelector('.formWithValidation')
    let phone = form.querySelector('.phone');
    if (phone['value'] == undefined || phone['value'] == '') {
        return;
    }
    let regex = /^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$/;

    if (!regex.test(phone['value'])) {
        let error = generateError('No valid phone');
        phone.parentElement.querySelector('.failing').append(error);
        phone['value'] = '';
        event.preventDefault();
    }
}

let age = function (date) {
    let today = new Date();
    let birthDate = new Date(date);
    let age = today.getFullYear() - birthDate.getFullYear();
    let m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

let checkAge = function (event) {
    let form = document.querySelector('.formWithValidation')
    let date = form.querySelector('.age')
    if (date['value'] == undefined || date['value'] == '') {
        return;
    }

    if (age(date['value']) < 18) {
        let error = generateError('Age must be of legal age');
        date.parentElement.querySelector('.failing').append(error);
        date['value'] = '';
        event.preventDefault();
    }
}

$(function () {
    $('#okno').on('submit', '.formWithValidation', function (event) {

        removeValidation();
        checkFieldsForEmptiness(event);
        checkPhoneForRegex(event);
        checkAge(event);
    });
});
