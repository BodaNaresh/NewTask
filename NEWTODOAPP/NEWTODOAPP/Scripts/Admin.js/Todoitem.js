
function drag(eve) {
    eve.dataTransfer.setData("text", eve.target.id);
}

function allowDrop(eve) {
    eve.preventDefault();
}

function drop(eve) {
    eve.preventDefault();
    var data = eve.dataTransfer.getData("text");
    eve.currentTarget.appendChild(document.getElementById(data));
}

//create todo
function createTask() {
   
    var Inpro = document.getElementById("Doing");
    var comp = document.getElementById("Done");
    var block = document.getElementById("create-new-task-block");
    if (Inpro.style.display === "none") {
        Inpro.style.display = "block";
        comp.style.display = "block";
        block.style.display = "none";
    } else {
        Inpro.style.display = "none";
        comp.style.display = "none";
        block.style.display = "flex";
    }
}


//save todo
function saveTask() {
       //Append todo to the board
      
        var todo = document.getElementById("Todo");
        var taskName = document.getElementById("task-name").value;
        todo.innerHTML += `
                <div class="task" id="${taskName.toLowerCase().split(" ").join("")}" draggable="true" ondragstart="drag(event)">
                    <span>${taskName}</span>
                </div>
                `;
        //var doing = document.getElementById("Doing");
        //var taskName1 = document.getElementById("task-name").value;
        //doing.innerHTML += `
        //    <div class="task" id="${taskName1.toLowerCase().split(" ").join("")}" draggable="true" ondragstart="drag(event)">
        //        <span>${taskName1}</span>
        //    </div>
        //    `;
   
        //var done = document.getElementById("Done");
        //var taskName2 = document.getElementById("task-name").value;
        //done.innerHTML += `
        //    <div class="task" id="${taskName2.toLowerCase().split(" ").join("")}" draggable="true" ondragstart="drag(event)">
        //        <span>${taskName2}</span>
        //    </div>
        //    `;
    
}


//Edit the task
function editTask() {
    var saveButton = document.getElementById("save-button");
    var editButton = document.getElementById("edit-button");
    if (saveButton.style.display === "none") {
        saveButton.style.display = "block";
        editButton.style.display = "none";
    } else {
        saveButton.style.display = "none";
        editButton.style.display = "block";
    }
}
