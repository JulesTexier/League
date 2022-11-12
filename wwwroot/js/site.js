// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

let form = document.getElementById('selectplayer');
console.log('hello', form);


form.addEventListener("oninput", function () {

    console.log('hello', form.value);
    form.submit();

});