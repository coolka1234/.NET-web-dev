﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const canvasElements = document.querySelectorAll(".drawingX");

canvasElements.forEach((canvas) => {

    const ctx = canvas.getContext("2d");

    canvas.addEventListener("mousemove", (event) => {

        const position = getMousePos(canvas, event);
        const mouseX = position.x;
        const mouseY = position.y;

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.beginPath();

        ctx.moveTo(0, 0);
        ctx.lineTo(mouseX, mouseY);

        ctx.strokeStyle = '#ff0000';

        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(canvas.width, 0);
        ctx.lineTo(mouseX, mouseY);

        ctx.strokeStyle = '#33FFE3';

        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(0, canvas.height);
        ctx.lineTo(mouseX, mouseY);

        ctx.strokeStyle = '#4CFF33';

        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(canvas.width, canvas.height);
        ctx.lineTo(mouseX, mouseY);

        ctx.strokeStyle = '#CE33FF';

        ctx.stroke();
    });


    canvas.addEventListener("mouseleave", () => {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    });
});

function getMousePos(canvas, evt) {
    var rect = canvas.getBoundingClientRect(),
        scaleX = canvas.width / rect.width,
        scaleY = canvas.height / rect.height;

    return {
        x: (evt.clientX - rect.left) * scaleX,
        y: (evt.clientY - rect.top) * scaleY
    }
}


document.getElementById("button").addEventListener("click", function () {
    var passedNumber = parseInt(document.getElementById("number").value);

    if (passedNumber < 5 || passedNumber > 20) {
        var param = document.createElement("p");
        param.innerText = "Podana wartość jest nieprawidłowa, dlatego przyjęto n=5";
        document.body.appendChild(param);
        passedNumber = 5;
    }

    const numbers = [];

    generateNumbers();
    generateTable();

    function generateNumbers() {
        for (var i = 0; i < passedNumber; i++) {
            numbers.push(Math.floor(Math.random() * 99) + 1);
        }
    }

    function generateTable() {
        var table = document.createElement("table");
        document.body.appendChild(table);

        var thead = document.createElement("thead");
        table.appendChild(thead);

        var tbody = document.createElement("tbody");
        table.appendChild(tbody);

        var headerRow = document.createElement("tr");
        thead.appendChild(headerRow);

        var rowHeader = document.createElement("th");
        rowHeader.textContent = "";
        rowHeader.classList.add("header");
        headerRow.appendChild(rowHeader);

        for (var i = 0; i < passedNumber; i++) {
            var columnHeader = document.createElement("th");
            columnHeader.textContent = numbers[i];
            columnHeader.classList.add("header");
            headerRow.appendChild(columnHeader);
        }

        for (var i = 0; i < passedNumber; i++) {
            var row = document.createElement("tr");
            tbody.appendChild(row);

            var rowHeader = document.createElement("th");
            rowHeader.textContent = numbers[i];
            rowHeader.classList.add("header");
            row.appendChild(rowHeader);

            for (var j = 0; j < passedNumber; j++) {
                var result = numbers[i] * numbers[j];
                var cell = document.createElement("td");
                cell.textContent = result;
                if (result % 2 === 0) {
                    cell.classList.add("even");
                } else {
                    cell.classList.add("odd");
                }
                row.appendChild(cell);

                (function (result) {
                    cell.addEventListener("click", function () {
                        alert(result);
                    });
                })(result);
            }
        }
    }
});