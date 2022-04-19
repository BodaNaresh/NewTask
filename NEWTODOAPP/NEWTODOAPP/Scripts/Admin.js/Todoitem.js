

let Todoitem = document.querySelector("#inputtext");
let addToDo = document.querySelector("#btn");
let TodoItems = document.querySelector("#tasks");

//let Inprogress = document.querySelector("#Doing"); 
//let Completed = document.querySelector("#Done");

let todos = [];

//Adding todos
addToDo.addEventListener('click', () => {
    if (Todoitem.value != '') {
        todos.push(Todoitem.value);
    }
    if (Todoitem.value == "") {
        alert("Please Enter Something");
        return;
    }

    Createtodo("");
    Todoitem.value = "";
});


//getting id from todos
var items = document.getElementsByClassName('actions');
var index;
for (index = 1; index<items.length; index++) {
    items[index].addEventListener('click', function () {
      index;
      console.log(index);
    });

}

//draggable functions
const Status = document.querySelectorAll('.todo_block');
let draggableItem = null;

function dragStart() {
        draggableItem = this;
    }

function dragEnd() {
        draggableItem = null;
    }

Status.forEach((list) => {
     list.addEventListener('dragover', dragOver);
     list.addEventListener('dragenter', dragEnter);
     list.addEventListener('dragleave', dragLeave);
     list.addEventListener('drop', Drop);
});

function dragOver(e) {
    e.preventDefault();
}

function dragEnter(e) {
        e.preventDefault();
    }

function dragLeave(e) {
        e.preventDefault();
       // console.log(user);
        console.log(e.target);
}

var id;

function Drop(e) {
    console.log(e);
    this.appendChild(draggableItem);
    var user = $(this).closest('Div').attr('id');
    console.log(user);

    id = e.srcElement.children[1].id;
    console.log(id);
    let newstatus = user;
    var url = 'http://localhost:62045/api/Update/UpdateStatus?id=' + id;
    var data = JSON.stringify({
        "TodoId":id,
        "Status": newstatus,
    });
    $.ajax({
        type: "PUT",
        data: data,
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(JSON.stringify(result));
        },
        error: function (error) {
            alert(error);
        },
    });
}

//Getting todos from database
$(document).ready(function () {
        GetTask();
})

var Todos;
function GetTask() {
        var url = 'http://localhost:62045/api/AdminApi/GetAllTodos';
        $.ajax({
            type: "GET",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                result.filter(result => {
                    if (result.Status == "Todo") {
                        Createtodo(result.Title, result.TodoId);
                        console.log(result);
                        // TodoItems.appendChild(Createtodo(result.Title, result.TodoId));
                        //TodoItems.appendChild(Createtodo(result.Title));
                    }
                    if (result.Status == "Doing") {
                        Createtodo(result.Title, result.TodoId);
                        console.log(result);
                        //var progress = document.createElement('Div');
                        //progress.innerText = Createtodo(result.Title);
                       // Inprogress.appendChild(Createtodo(result.Title));

                    }
                    if (result.Status == "Done") {                   
                        Createtodo(result.Title, result.TodoId);
                        console.log(result);
                        //var comp = document.createElement('Div');
                        //comp.innerHTML = Createtodo(result.Title);
                        //Completed.appendChild(comp);
                    }
                });
                //for (var i = 0; i <= result.length; i++) {
                //    Createtodo(result[i].Title);
                //    console.log(result[i]);
                //}
                alert(JSON.stringify(result));
                console.log(result);

            },
            error: function (error) {
                alert(error);
            },
        });
}

//Create Todo
function Createtodo(value,id) {
        let ToDoList = document.createElement('div');
        ToDoList.classList.add('ToDoList');

        // creating div element
        let todo = document.createElement('div');
        todo.classList.add('todo');

        ToDoList.setAttribute("draggable", "true");
    ToDoList.setAttribute("id", id);
    console.log("getting id" + id);
        ToDoList.addEventListener("dragstart", dragStart);
        ToDoList.addEventListener("dragend", dragEnd);

        // creating input element
        let todo_input_element = document.createElement('input');
        todo_input_element.classList.add('text');
        todo_input_element.type = 'text';
        todo_input_element.value = value;
        todo_input_element.setAttribute("readonly", "readonly");
        todo.appendChild(todo_input_element);

        //code for div element
        let todo_actions = document.createElement('div');
        todo_actions.classList.add('actions');

        // code for creating edit button
        let todo_edit = document.createElement('button');
        todo_edit.classList.add('edit');
        todo_edit.innerHTML = 'Edit';

        // code for creating delete button
        let todo_delete = document.createElement('button');
        todo_delete.classList.add('delete');
        todo_delete.innerHTML = 'X';

        //apending actions to todo actions
        ToDoList.appendChild(todo);

        todo_actions.appendChild(todo_edit);
        todo_actions.appendChild(todo_delete);
        ToDoList.appendChild(todo_actions);
        TodoItems.appendChild(ToDoList);


    //Edit Functionality
    todo_edit.addEventListener('click', () => {
        if (todo_edit.innerText.toLowerCase() == 'edit') {
            todo_input_element.removeAttribute("readonly");
            todo_input_element.focus();
            todo_edit.innerText = "Update";
        } else {
            todo_input_element.setAttribute("readonly", "readonly");
            todo_edit.innerText = "Edit";
            var Val = todo_input_element.value;
            console.log(Val);

            var ids = id;
            let Title = Val;
            var url = 'http://localhost:62045/api/AdminApi/UpdateToDo?id=' + ids;
            var data = JSON.stringify({
                "TodoId": ids,
                "Title": Title,
            });
            $.ajax({
                type: "PUT",
                data: data,
                url: url,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    alert(result);
                },
                error: function (error) {
                    alert(error);
                },
            });
        }
    });


   //delete Functionality
    todo_delete.addEventListener('click', () => {
        TodoItems.removeChild(ToDoList);
        var deleteId = id;
        var url = 'http://localhost:62045/api/AdminApi/DeleteToDo?id=' + deleteId;
        $.ajax({
            type: "DELETE",
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert(result);
            },
            error: function (error) {
                alert(error);
            },
        });
    });
}

//save todo in database
function saveTask() {
        let Title = $("#inputtext").val();
        var url = 'http://localhost:62045/api/AdminApi/PostToDo';
        var data = JSON.stringify({
            "Title": Title,
            "Status": "Todo",
        });
        $.ajax({
            type: "POST",
            data: data,
            url: url,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert(result);
            },
            error: function (error) {
                alert(error);
            },
        });
}



