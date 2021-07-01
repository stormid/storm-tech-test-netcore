// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const _sortAsc = "asc";
const _sortDesc = "desc";

function filterHiddenItems(element) {

    let elements = document.querySelectorAll('[data-isDone="True"]');
    let displayVal = element.checked ? "none" : "block";
        
    for (let i = 0; i < elements.length; i++) 
        elements[i].style.display = displayVal; 
}

function sortByRank(element) {

    let elements = document.querySelectorAll('[data-rank]');
    let divs = Array.from(elements);
    let currentSort = element.getAttribute('data-sort-direction');

    //list loads from server ordered by rank asc.
    let sorted = divs.reverse();;

    if (currentSort === _sortAsc)
        element.dataset.sortDirection = _sortDesc;
    else if (currentSort === _sortDesc) 
        element.dataset.sortDirection = _sortAsc;

    console.log(element)
    element.innerHTML = 'Sorted By Rank > ' + element.dataset.sortDirection;
    
    if (sorted !== undefined)
        sorted.forEach(e => document.querySelector("#toDoList").appendChild(e));
}

function SetRankApi() {
    alert("test");
}



