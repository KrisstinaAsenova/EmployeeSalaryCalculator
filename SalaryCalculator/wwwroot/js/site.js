$('#btn').on('click', () => {
    let div = document.getElementById('div');
    let email = document.getElementById('personemail').value;
    let salary = document.getElementById('salary').value

    $.ajax({
        type: 'post',
        url: 'CreateAsync',
        data: {
            __RequestVerificationToken: gettoken(),
            PersonEmail: email,
            GrossSalary: salary
        },
        success: function (data) {
            document.getElementById('netsalary').value = data;
            document.getElementById('tax').value = Math.round((salary - data) * 100) / 100;
        }

    })
    div.removeAttribute('style');
});