// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function filterHiddenItems(element) {

    let elements = document.querySelectorAll('[data-isDone="True"]');
    let displayVal = element.checked ? "none" : "block";
        
    for (let i = 0; i < elements.length; i++) 
        elements[i].style.display = displayVal; 
}