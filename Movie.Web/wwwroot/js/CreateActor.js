let actorCreateButton = $('#js-create-submitactor');
actorCreateButton.on('click', () => {
    let firstName = $('#js-create-actorfname');
    let lastName = $('#js-create-actorlname');
    let profile = $('#js-create-actorpic');
    let bioLink = $('#js-create-actorbio');

    let data = {
        firstName: firstName.val(),
        lastName: lastName.val(),
        profile: profile.val(),
        bioLink: bioLink.val(),
    };

    $.ajax({
        type: 'POST',
        url: '/actor/submit',
        contentType: 'application/json',
        accept: 'application / json',
        data: JSON.stringify(data),
        dataType: 'json'
    }).done(_project => {

        //no success or failure response implemented yet.

        var url = "/Home/Index/";
        window.location.href = url;

    }).fail(_failureResponse => {

        var url = "/Home/Index/";
        window.location.href = url;
    });
});