#pragma checksum "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba53ef0fd95cb6e815f90639aeb480cd28f8c2b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Boards_Read), @"mvc.1.0.view", @"/Views/Boards/Read.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\_ViewImports.cshtml"
using trello_clone.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\_ViewImports.cshtml"
using trello_clone.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba53ef0fd95cb6e815f90639aeb480cd28f8c2b1", @"/Views/Boards/Read.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26ce59f7b614185b800f4aab2577c28592c4b447", @"/Views/_ViewImports.cshtml")]
    public class Views_Boards_Read : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
  
    string bgImg = "";
    try
    {
        bgImg = @ViewBag.BoardInfo.prefs.backgroundImage;
    }
    catch
    {
        bgImg = "https://i.pinimg.com/736x/2f/60/6a/2f606ad14bf9171e5f41b42a01b4441f.jpg";
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    * {\r\n        padding: 0;\r\n        margin: 0;\r\n    }\r\n\r\n    body {\r\n        background-image: url(\"");
#nullable restore
#line 20 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                          Write(bgImg);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""");
        background-repeat: repeat-x;
        background-size: cover;
        font-family: ""Open Sans"";
    }

    .container {
        margin: 0;
        padding: 0;
    }

    button {
        outline: none;
        cursor: pointer;
    }

    #addTodoListDiv {
        margin-left: 2em;
        margin-bottom: -18px;
    }

    #addTodoListDiv button {
        margin-left: 0.5em;
    }


    #root {
        margin: 10px;
        /*border: 1px solid grey;*/
        /*display: flex;*/
");
            WriteLiteral(@"width: 3000px;
    }


    .todoList {
        /*border: 1px solid red;*/
        width: 300px;
        border-radius: 4px;
        min-height: 100px;
        background: rgb(235, 235, 235);
        padding: 0.7em;
        margin: 1em 0 1em 1em;

        float: left;
    }

    .todoList h2 {
        font-size: 1em;
        margin-bottom: 0.5em;
    }

    #to-do-list-button {
        margin-left: 0.5em;
    }

    .card {
        /*border: 1px solid blue;*/
        border-radius: 4px;
        border-bottom: rgb(180, 180, 180) 1px solid;
        background: white;
        margin: 0.5em 0 0 0;
        padding: 0.5em;
        font-size: 0.9em;
        position: relative;

        display: flex;
        justify-content: space-between;

        cursor: pointer;
    }

    .card button {
        visibility: hidden;
        height: max-content;

        background: none;
        border: none;
        padding: 0.3em;

    }


    .card:hover button {
        visib");
            WriteLiteral(@"ility: visible;
    }

    .card button:hover {
        background-color: rgb(235, 235, 235);
        border-radius: 4px;
        cursor: pointer;
    }


    .menuContainer {
        display: flex;

        position: absolute;
        top: 0;
        left: 0;
        background-color: rgba(0, 0, 0, 0.8);
        width: 100%;
        height: 100%;
    }

    .menu {
        top: 0;
        left: 0;
        background-color: rgb(235, 235, 235);
        width: 500px;
        min-height: 300px;

        margin: auto;

        padding: 1em;
        border-radius: 4px;

    }

    .menuTitle {
        font-weight: bold;
        font-size: 1.5em;
        margin-bottom: 1em;
    }

    .menuDescription {
        margin-bottom: 2em;
        line-height: 1.5em;
    }

    .menuDescription textarea {
        width: 100%;
        height: 5em;
        padding: 0.5em;
        font-size: 1.1em;
    }

    .menuComments {
        width: 200px;
    }

    .comment {
 ");
            WriteLiteral(@"       background-color: white;
        border: 1px solid #ccc;
        border-radius: 4px;
        margin-top: 0.5em;
        padding: 0.5em;
        font-size: 0.8em;
    }

    .commentsInput {
        margin-right: 0.5em;
    }

    .btn-save {
        background-color: #5aac44;
        color: white;
        border: none;
        border-radius: 4px;

        padding: 0.5em;
        margin-top: 0.5em;

    }

");
            WriteLiteral("    .sideRight {\r\n        width: 200px;\r\n        height: 200px;\r\n        background-color: aqua;\r\n        float: right;\r\n    }\r\n</style>\r\n");
            WriteLiteral(@"<div id=""addTodoListDiv"">
    <input id=""addTodoListInput"" class=""comment"">
    <button id=""addTodoListButton"" class=""btn-save"">Add list</button>
</div>
<div id=""root"">

</div>

<script type=""text/javascript"">
    let root = document.getElementById(""root"");
    const API_URL = ""https://localhost:44395"";
");
#nullable restore
#line 204 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
      
            
        var boardId = ViewBag.BoardId;
        var token = ViewBag.Token;

    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    

    class todoList {
        constructor(place, id, title = ""to-do list"") {

            this.place = place;
            this.title = title;
            this.cardArray = [];
            this.id = id;
            this.render();
        }

        async addToDo() {
            let text = this.input.value;
            var card = await createCardFetch(this.id, { ""name"": text });
            this.cardArray.push(new Card(text, card.id, this.div, this));
        }

        moveTodo(card, toList) {
            console.log(""move"");
        }

        addToDoWithName(nameCard, idCard) {
            this.cardArray.push(new Card(nameCard, idCard, this.div, this));
        }

        render() {
            this.createToDoListElement();
            this.place.append(this.todoListElement);
        }

        createToDoListElement() {
            //Create elements
            this.h2 = document.createElement('h2');
            this.h2.innerText = this.title;
            this.input = d");
            WriteLiteral(@"ocument.createElement('input');
            this.input.classList.add(""comment"");
            this.button = document.createElement('button');
            this.button.innerText = 'Add';
            this.button.classList.add(""btn-save"");
            this.button.id = ""to-do-list-button"";
            this.div = document.createElement('div');
            this.todoListElement = document.createElement('div');

            //Add Event listener
            this.button.addEventListener('click', () => {
                if (this.input.value != """") {
                    this.addToDo.call(this);
                    this.input.value = """";
                }
            });

            //Append elements to the to-do list element
            this.todoListElement.append(this.h2);
            this.todoListElement.append(this.input);
            this.todoListElement.append(this.button);
            this.todoListElement.append(this.div);
            this.todoListElement.classList.add(""todoList"");
           ");
            WriteLiteral(@" this.todoListElement.id = this.id;
        }
    }


    class Card {
        constructor(text, id, place, todoList) {

            this.place = place;
            this.todoList = todoList;
            this.state = {
                text: text,
                description: ""Click to write a description..."",
                comments: []
            }
            this.id = id;
            this.render();
        }

        render() {
            this.card = document.createElement('div');
            this.card.classList.add(""card"");
            this.card.id = this.id;
            this.card.addEventListener('click', (e) => {
                if (e.target != this.deleteButton) {
                    this.showMenu.call(this);
                }
            });

            this.p = document.createElement('p');
            this.p.innerText = this.state.text;

            this.deleteButton = document.createElement('button');
            this.deleteButton.innerText = ""X"";
            thi");
            WriteLiteral(@"s.deleteButton.addEventListener('click', () => {
                this.deleteCard.call(this);
            });

            this.card.append(this.p);
            this.card.append(this.deleteButton);

            this.place.append(this.card);
        }

        deleteCard() {
            deleteCardAsync(this.id);
            this.card.remove();
            let i = this.todoList.cardArray.indexOf(this);
            this.todoList.cardArray.splice(i, 1);
        }

        async showMenu() {

            //Create elements
            this.menu = document.createElement(""div"");
            this.menuContainer = document.createElement(""div"");
            this.menuTitle = document.createElement(""div"");
            this.menuDescription = document.createElement(""div"");
            this.commentsInput = document.createElement(""input"");
            this.commentsButton = document.createElement('button');
            this.menuComments = document.createElement(""div"");

            this.sideRight = do");
            WriteLiteral(@"cument.createElement(""div"")
            var LISTS = await fetchLists();
            let listString = ""Move card to:</br><a>"";
            for(var i =0; i<LISTS.length; i++) {
                listString += LISTS[i].name + ""</br>"";
            }
            listString += ""</a>"";
            

            //Add class names
            this.menu.className = ""menu"";
            this.menuContainer.className = ""menuContainer"";
            this.menuTitle.className = ""menuTitle"";
            this.menuDescription.className = ""menuDescription"";
            this.menuComments.className = ""menuComments"";
            this.commentsInput.className = ""commentsInput comment"";
            this.commentsButton.className = ""commentsButton btn-save"";
            this.sideRight.className = ""sideRight"";

            //Add inner Text
            this.commentsButton.innerText = ""Add"";
            this.commentsInput.placeholder = ""Write a comment..."";

            //Event listeners
            this.menuContainer.a");
            WriteLiteral(@"ddEventListener('click', (e) => {
                console.log(e.target);
                if (e.target.classList.contains(""menuContainer"")) {
                    this.menuContainer.remove();
                }
            });

            this.commentsButton.addEventListener('click', () => {
                if (this.commentsInput.value != """") {
                    this.state.comments.push(this.commentsInput.value);
                    this.renderComments();
                    this.commentsInput.value = """";
                }
            })

            //Append
            this.menu.append(this.menuTitle);
            this.menu.append(this.menuDescription);
            this.menu.append(this.commentsInput);
            this.menu.append(this.commentsButton);
            this.menu.append(this.sideRight);
            this.sideRight.innerHTML = listString;
            this.menu.append(this.menuComments);

            this.menuContainer.append(this.menu);
            root.append(this.menuCont");
            WriteLiteral(@"ainer);

            this.editableDescription = new EditableText(this.state.description, this.menuDescription, this, ""description"", ""textarea"", ""editDescription"");
            this.editableTitle = new EditableText(this.state.text, this.menuTitle, this, ""text"", ""input"", ""editCard"");

            this.renderComments();
        }

        renderComments() {

            let currentCommentsDOM = Array.from(this.menuComments.childNodes);

            currentCommentsDOM.forEach(commentDOM => {
                commentDOM.remove();
            });

            this.state.comments.forEach(comment => {
                new Comment(comment, this.menuComments, this);
            });
        }
    }

    class EditableText {
        constructor(text, place, card, property, typeOfInput, typeOfEdit = """") {
            this.typeOfEdit = typeOfEdit;
            this.text = text;
            this.place = place;
            this.card = card;
            this.property = property;
            this.type");
            WriteLiteral(@"OfInput = typeOfInput;

            this.render();
        }

        render() {
            this.div = document.createElement(""div"");
            this.p = document.createElement(""p"");

            this.p.innerText = this.text;

            this.p.addEventListener('click', () => {
                this.showEditableTextArea.call(this);
            });

            this.div.append(this.p);
            this.place.append(this.div);
        }

        showEditableTextArea() {
            let oldText = this.text;

            this.input = document.createElement(this.typeOfInput);
            this.saveButton = document.createElement(""button"");

            this.p.remove();
            this.input.value = oldText;
            this.saveButton.innerText = ""Save"";
            this.saveButton.className = ""btn-save"";
            this.input.classList.add(""comment"");

            this.saveButton.addEventListener('click', () => {
                this.text = this.input.value;
                thi");
            WriteLiteral(@"s.card.state[this.property] = this.input.value;
                if (this.property == ""text"") {
                    this.card.p.innerText = this.input.value;
                }
                this.div.remove();
                this.render();
            });

            function clickSaveButton(event, object, typeOfEdit, cardId, text) {
                // Number 13 is the ""Enter"" key on the keyboard
                if (event.keyCode === 13) {
                    if (typeOfEdit == ""editCard"") {
                        updateCardAsync(cardId, { ""name"": text });
                    }
                    // Cancel the default action, if needed
                    event.preventDefault();
                    // Trigger the button element with a click
                    object.saveButton.click();
                }
            }

            this.input.addEventListener(""keyup"", (e) => {
                if (this.typeOfInput == ""input"") {
                    clickSaveButton(e, this, this.typeOfEd");
            WriteLiteral(@"it, this.card.id, this.input.value);
                }
            });

            this.div.append(this.input);

            if (this.typeOfInput == ""textarea"") {
                this.div.append(this.saveButton);
            }

            this.input.select();
        }

    }

    class Comment {
        constructor(text, place, card) {
            this.text = text;
            this.place = place;
            this.card = card;
            this.render();
        }

        render() {
            this.div = document.createElement('div');
            this.div.className = ""comment"";
            this.div.innerText = this.text;

            this.place.append(this.div);
        }
    }



    //-------------main------------

    let addTodoListInput = document.getElementById(""addTodoListInput"");
    let addTodoListButton = document.getElementById(""addTodoListButton"");

    addTodoListButton.addEventListener('click', () => {
        if (addTodoListInput.value.trim() != """") {");
            WriteLiteral("\n            new todoList(root, addTodoListInput.value);\r\n            addTodoListInput.value = \"\";\r\n        }\r\n    });\r\n\r\n    async function fetchLists(boardId = \"");
#nullable restore
#line 510 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                    Write(boardId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\") {\r\n        var url = API_URL + \"/api/Boards/\" + boardId + \"/lists?Token=\" + \"");
#nullable restore
#line 511 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                                                     Write(token);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        try {
            let res = await fetch(url);
            return await res.json();
        } catch (error) {
            console.log(error);
        }
    }

    async function fetchCards(listId) {
        var url = API_URL + ""/api/lists/"" + listId + ""/cards?Token="" + """);
#nullable restore
#line 521 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                                                   Write(token);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        try {
            let res = await fetch(url);
            return await res.json();
        } catch (error) {
            console.log(error);
        }
    }

    async function showBoard() {
        var LISTS = await fetchLists();
        var lenList = LISTS.length;
        for (var i = 0; i < lenList; i++) {
            let tdList = new todoList(root, LISTS[i].id, LISTS[i].name);
            let cards = await fetchCards(LISTS[i].id);
            cards.forEach(card => {
                tdList.addToDoWithName(card.name, card.id);
            })
        }
    }

    // NEED to FIX it and fix create card API
");
            WriteLiteral("    async function createCardFetch(listId, card) {\r\n        var url = \"https://api.trello.com/1/cards?idList=\" + listId + \"&key=07e57a8c0ff7205b8202479a1d9ed50d\" + \"&token=\" + \"");
#nullable restore
#line 559 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                                                                                                        Write(token);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        const response = await fetch(url, {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(card)
        });
        return response.json();
    }

    async function deleteCardAsync(cardId) {
        var url = API_URL + ""/api/cards/"" + cardId + ""?Token="" + """);
#nullable restore
#line 575 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                                             Write(token);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        const response = await fetch(url, {
            method: 'DELETE',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
        });
    }

    async function updateCardAsync(cardId, card) {
        var url = API_URL + ""/api/cards/"" + cardId + ""?Token="" + """);
#nullable restore
#line 585 "E:\.NET\API\trello-clone-solution\trello-clone.web\Views\Boards\Read.cshtml"
                                                             Write(token);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        const response = await fetch(url, {
            method: 'PUT',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: { 'Content-type': 'application/json; charset=UTF-8' },
            body: JSON.stringify(card)
        });
        return response.json();
    }

    showBoard();

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
