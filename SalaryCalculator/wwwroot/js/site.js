function test() {
    let div = document.getElementById('div');
    let email = document.getElementById('personemail').value;
    let salary = document.getElementById('salary').value
    let country = document.getElementById('takecountry').getAttribute('data-value');
    let isEverythingOk = true;
    let isvalidemail = validateEmail(email);

    if (isNaN(salary)) {
        $('#salaryvalidation').text('Please enter valid salary');
        isEverythingOk = false;
    }
    else {
        $('#salaryvalidation').text('');
    }
    if (!salary) {
        $('#salaryvalidation').text('Please enter salary');
        isEverythingOk = false;
    }
    else if (!isNaN(salary)) {
        $('#salaryvalidation').text('');
    }
    if (salary < 0) {
        $('#salaryvalidation').text('Please enter valid salary');
        isEverythingOk = false;
    }
    if (salary.length >6 
) {
        $('#salaryvalidation').text('Please enter valid salary');
        isEverythingOk = false;
    }
    if (!email) {
        $('#emailValidation').text('Please enter email');
        isEverythingOk = false;
    }
    else {
        $('#emailValidation').text('');
    }
    if (!isvalidemail) {
        $('#emailValidation').text('Please enter valid email');
        isEverythingOk = false;
    }
    else {
        $('#emailValidation').text('');
    }
    if (isEverythingOk) {

        $.ajax({
            type: 'post',
            url: 'Country/CreateAsync',
            data: {
                __RequestVerificationToken: gettoken(),
                PersonEmail: email,
                GrossSalary: salary,
                Country: country
            },
            success: function (data) {
                document.getElementById('netsalary').value = data;
                document.getElementById('tax').value = Math.round((salary - data) * 100) / 100 ;
            }

        })
        div.removeAttribute('style');
    }
};
$('#btn').on('click', () => {
    test();
});
document.onkeyup = function (e) {
    if (e.which === 13) {
        test();
    };
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}