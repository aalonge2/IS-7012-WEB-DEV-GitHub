// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Add interactivity for Razor Pages project

// Example: Handle form submission with client-side validation
document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");
    if (form) {
        form.addEventListener("submit", function (event) {
            const inputs = form.querySelectorAll("input[required], textarea[required]");
            let isValid = true;

            inputs.forEach(input => {
                if (!input.value.trim()) {
                    isValid = false;
                    input.classList.add("is-invalid");
                } else {
                    input.classList.remove("is-invalid");
                }
            });

            if (!isValid) {
                event.preventDefault();
                alert("Please fill out all required fields.");
            }
        });
    }
});

// Example: AJAX request to fetch data dynamically
function fetchData(url, callback) {
    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        })
        .then(data => callback(data))
        .catch(error => console.error("Fetch error:", error));
}

// Example: Toggle visibility of an element
document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.querySelector("#toggleButton");
    const toggleElement = document.querySelector("#toggleElement");

    if (toggleButton && toggleElement) {
        toggleButton.addEventListener("click", function () {
            const isHidden = toggleElement.style.display === "none";
            toggleElement.style.display = isHidden ? "block" : "none";
        });
    }
});
