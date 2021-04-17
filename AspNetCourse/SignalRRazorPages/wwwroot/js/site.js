let userName;
let apiBaseUrl;
let connection;

function getUserName() {
    userName = prompt("Podaj imię")
    if (!userName) {
        alert("Nie podano nazwy uzytkownika, odśwież stronę!");
        throw "No user name";
    }
}

function buildConnection(url) {
    apiBaseUrl = url;
    connection = new signalR.HubConnectionBuilder()
        .withUrl(`${apiBaseUrl}/api`)
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("newMessage", newMessage);
    connection.onclose(() => console.log("Disconected"));
    connection.start()
        .then(() => {
            console.log("Connection starts")
            getUserName();
        })
        .catch(console.error)
}
function sendNewMessage(e) {
    if (e.keyCode == 13) {
        let input = document.getElementById('messageInput').value;
        document.getElementById('messageInput').value = '';
        return sendMessage(input)
    }
}
function sendMessage(message) {
    return axios.post(`${apiBaseUrl}/api/messages`, {
        sender: userName,
        text: message
    }).then(resp => resp.data);
}
function newMessage(message) {
    let messages = document.getElementById('messages');
    let temlateChildren = document.getElementById('messageTemaplate').content.children[0];
    temlateChildren.children[0].children[0].innerText = message.sender;
    temlateChildren.children[0].children[1].innerHTML = new Date().toISOString();
    temlateChildren.children[1].innerHTML = message.text;
    let template = document.getElementById('messageTemaplate').content.cloneNode(true);
    messages.insertBefore(template, messages.firstChild);
}
