var ViewModel = function () {
    var mypets = this;
    mypets.pets = ko.observableArray();
    mypets.error = ko.observable();

    var mypetsUri = '/api/Pet/';

    function ajaxHelper(uri, method, data) {
        mypets.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            mypets.error(errorThrown);
        });
    }

    function getAllPets() {
        ajaxHelper(petsUri, 'GET').done(function (data) {
            mypets.pets(data);
        });
    }

    // Fetch the initial data.
    getAllPets();
};

ko.applyBindings(new ViewModel());

mypets.petOwner = ko.observableArray();
mypets.newpet = {
    Id: ko.observable(),
    Name: ko.observable(),
    DateOfBirth: ko.observable(),
    Owner: ko.observable()
}

var authorsUri = '/api/Pet/';

function getAuthors() {
    ajaxHelper(authorsUri, 'GET').done(function (data) {
        mypets.pets(data);
    });
}

mypets.addpets = function (formElement) {
    var pet = {
        d: mypets.newpet.pets().Id,
        Name: mypets.newpet.Name(),
        DateOfBirth: mypets.newpet.DateOfBirth(),
        Owner: mypets.newpet.Owner()
    };

    ajaxHelper(petsUri, 'POST', book).done(function (item) {
        mypets.pet.push(item);
    });
}

getPets();