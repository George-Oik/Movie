let movieCreateButton = $('#js-create-submitmovie');
movieCreateButton.on('click', () => {
    let name = $('#js-create-moviename');
    let releaseDate = $('#js-create-releasedate');
    let plot = $('#js-create-plot');
    let genre = $('#js-create-genre');
    let poster = $('#js-create-poster');
    let trailer = $('#js-create-trailer');

    var images = [];
    let im1 = $('#js-create-image1');
    let im2 = $('#js-create-image2');
    let im3 = $('#js-create-image3');
    let im4 = $('#js-create-image4');
    let im5 = $('#js-create-image5');

    let title1 = $('#js-create-title1');
    let title2 = $('#js-create-title2');
    let title3 = $('#js-create-title3');
    let title4 = $('#js-create-title4');
    let title5 = $('#js-create-title5');

    if (im1) {
        let image1 = {
            title: title1.val(),
            link: im1.val(),
        }
        images.push(image1);
    }
    if (im2) {
        let image2 = {
            title: title2.val(),
            link: im2.val(),
        }
        images.push(image2);
    }
    if (im3) {
        let image3 = {
            title: title3.val(),
            link: im3.val(),
        }
        images.push(image3);
    }
    if (im4) {
        let image4 = {
            title: title4.val(),
            link: im4.val(),
        }
        images.push(image4);
    }
    if (im5) {
        let image5 = {
            title: title5.val(),
            link: im5.val(),
        }
        images.push(image5);
    }

    let cast = [];

    let fn1 = $('#js-a1-firstname');
    let fn2 = $('#js-a2-firstname');
    let fn3 = $('#js-a3-firstname');

    let ln1 = $('#js-a1-lastname');
    let ln2 = $('#js-a2-lastname');
    let ln3 = $('#js-a3-lastname');

    let role1 = $('#js-a1-role');
    let role2 = $('#js-a2-role');
    let role3 = $('#js-a3-role');

    if (fn1) {
        let actor = {
            firstName: fn1.val(),
            lastName: ln1.val(),
        }
        let cast1 = {
            actor: actor,
            role: role1.val(),
        }
        cast.push(cast1);
    }
    if (fn2) {
        let actor = {
            firstName: fn2.val(),
            lastName: ln2.val(),
        }
        let cast2 = {
            actor: actor,
            role: role2.val(),
        }
        cast.push(cast2);
    }
    if (fn3) {
        let actor = {
            firstName: fn3.val(),
            lastName: ln3.val(),
        }
        let cast3 = {
            actor: actor,
            role: role3.val(),
        }
        cast.push(cast3);
    }

    let data = {
        name: name.val(),
        plot: plot.val(),
        releaseDate: releaseDate.val(),
        cast: cast,
        poster: poster.val(),
        images: images,
        trailer: trailer.val(),
        genre: genre.val(),
    };

    $.ajax({
        type: 'POST',
        url: '/movie/submit',
        contentType: 'application/json',
        accept: 'application / json',
        data: JSON.stringify(data),
        dataType: 'json'
    }).done(_project => {

        var url = "/Home/Index/";
        window.location.href = url;

    }).fail(_failureResponse => {

        var url = "/Home/Index/";
        window.location.href = url;
    });
});