// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.getElementById('clientForm').addEventListener('submit', function (event) {
    event.preventDefault();
    var form = event.target;
    var formData = new FormData(form);

    fetch('https://localhost:7029/api/clients', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (response.ok) {
                document.getElementById('message').innerText = 'Client created successfully.';
                document.getElementById('message').style.display = 'block';
                form.reset();
            } else if (response.status === 409) {
                response.text().then(errorMessage => {
                    document.getElementById('message').innerText = errorMessage;
                    document.getElementById('message').style.display = 'block';
                });
            } else {
                throw new Error('Failed to create client.');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            document.getElementById('message').innerText = 'An error occurred.';
            document.getElementById('message').style.display = 'block';
        });
});

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('clientForm').addEventListener('submit', function (event) {
        event.preventDefault();
        var form = event.target;
        var formData = new FormData(form);

        fetch('https://localhost:7029/api/clients', {
            method: 'POST',
            body: formData
        })
            .then(response => {
                if (response.ok) {
                    document.getElementById('message').innerText = 'Client created successfully.';
                    document.getElementById('message').style.display = 'block';
                    form.reset();
                } else if (response.status === 409) {
                    response.text().then(errorMessage => {
                        document.getElementById('message').innerText = errorMessage;
                        document.getElementById('message').style.display = 'block';
                    });
                } else {
                    throw new Error('Failed to create client.');
                }
            })
            .catch(error => {
                console.error('Error:', error);
                document.getElementById('message').innerText = 'An error occurred.';
                document.getElementById('message').style.display = 'block';
            });
    });
});


//document.getElementById('searchButton').addEventListener('click', function () {
//    var searchIdNumber = document.getElementById('searchIdNumber').value;

//    fetch(`https://localhost:7029/api/clients/${searchIdNumber}`)
//        .then(response => {
//            if (response.ok) {
//                return response.json();
//            } else {
//                throw new Error('Failed to fetch client.');
//            }
//        })
//        .then(data => {
//            // Display the client information
//            console.log(data);
//        })
//        .catch(error => {
//            console.error('Error:', error);
//        });
//});
