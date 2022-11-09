// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



//-----------------Modular Form JavaScript - Begin -----------------------
var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
    // This function will display the specified tab of the form ...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";

    // ... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        var btn = document.getElementById("nextBtn");
        btn.classList.add('btn');
        btn.classList.add('btn-success');
        btn.classList.add('mb-3');
        document.getElementById("nextBtn").innerHTML = "Submit";
    } else {
        var btn = document.getElementById("nextBtn");
        btn.classList.add('btn');
        btn.classList.add('btn-primary');
        btn.classList.add('mb-3');
        document.getElementById("nextBtn").innerHTML = "Save & Next";
    }
    // ... and run a function that displays the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form... :
    if (currentTab >= x.length) {
        //...the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " valid";
            // and set the current valid status to false:
            valid = true;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class to the current step:
    x[n].className += " active";
}

//-----------------Modular Form JavaScript - End -----------------------

function update() {
    sel = document.getElementById("noteList");
    display = document.getElementById("selectedNote");

    if (sel.value == "null") {
        document.getElementById("selectedNote").removeAttribute("readonly");
        display.value = "";
        display.placeholder = "Enter custom note...";
    } else if (sel.value == "HS") {
        display.value = "The sub floor inspection is limited to the immediate area of the access hatch. This is due to current New Zealand legislation Health & Safety at work Act 2015 with regards to working in confined spaces. Due to the limited ability to inspect the sub floor it is marked as not inspected on the certificate of inspection.";
        document.getElementById('selectedNote').readOnly = true;
    } else {
        display.value = "No note selected";
    }
}

function updateMaintenanceKey() {
    sel = document.getElementById("maintenanceList");
    display = document.getElementById("selectedMaintenanceNote");

    if (sel.value == "NMR") {
        display.value = "No maintenance required";
        document.getElementById("colorBox").style.backgroundColor = "#7cb343";
        document.getElementById("MaintenanceRatingKeyColor").value = "#7cb343";
    } else if (sel.value == "SMR") {
        display.value = "Some maintenance required";
        document.getElementById("colorBox").style.backgroundColor = "#ff9900";
        document.getElementById("MaintenanceRatingKeyColor").value = "#ff9900";
    } else if (sel.value == "UMR") {
        display.value = "Urgent maintenance required";
        document.getElementById("colorBox").style.backgroundColor = "#f44431";
        document.getElementById("MaintenanceRatingKeyColor").value = "#f44431";
    } else if (sel.value == "UVI") {
        display.value = "Unable to visibly inspect";
        document.getElementById("colorBox").style.backgroundColor = "#2096f7";
        document.getElementById("MaintenanceRatingKeyColor").value = "#2096f7";
    } else {
        display.value = "No note selected";
        document.getElementById("colorBox").style.backgroundColor = "#000000";
        document.getElementById("MaintenanceRatingKeyColor").value = "#000000";
    }
}

function updateFoundationType() {
    sel = document.getElementById("foundationTypeList");
    display = document.getElementById("selectedFoundationTypeNote");

    if (sel.value == "TB2") {
        display.value = "Type B2";
    } else if (sel.value == "WDN") {
        display.value = "Wooden";
    } else if (sel.value == "STL") {
        display.value = "Steel";
    } else if (sel.value == "CON") {
        display.value = "Concrete";
    } else {
        display.value = "No type selected";
    }
}

