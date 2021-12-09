function addUser() {

    document.getElementById("newUser").style.display = "block";
}

function addNewUser() {
    //debugger
    let user = {

        UserName: document.getElementById("NewUserName").value,

        Password: document.getElementById("UserPassword").value,

        eMail: document.getElementById("NewUserMail").value
    };

    fetch("api/Values", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(user),
    }).then(response => {
        if (response.ok)
            alert("!!!משתמש נוסף בהצלחה");
        else response.json().then(err => { alert(JSON.stringify(err.errors)) });
    })
        .catch(error => { console.log(error); });

}

function login() {
    //debugger

    let email = document.getElementById("UserMail").value;
    let password = document.getElementById("UserPass").value;

    //debugger
    fetch("api/Values/" + email + "/" + password)
        .then(response => {
            if (response.status == 204)
                alert("שם משתמש וסיסמא אינם תקינים");
            else if (response.ok) {
                alert("החיפוש עבר בהצלחה👍");
                return response.json();
            } else {
                alert("🙁לא נמצא משתמש");
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            sessionStorage.setItem('HiUser', JSON.stringify(data));
            window.location.href = "Welcome.html";
        })
        .catch(error => { console.log(error + "לא נמצאו נתונים👎"); });
}

function wellcom() {
    //debugger
    var user = JSON.parse(sessionStorage.getItem("HiUser"));
    document.getElementById("hi").innerHTML = "<h1 >Hello " + user.userName + "!!!</h1 >";
}

function forupdate() {
    document.getElementById("up").style.display = "block"
}

function update() {
    //debugger

    let upUser = {
        UserName: document.getElementById("upUserName").value,
        Password: document.getElementById("upUserPass").value,
        EMail: document.getElementById("upUserMail").value
    }
    //debugger
    let user1 = JSON.parse(sessionStorage.getItem("HiUser"));

    fetch("api/Values/" + user1.userId, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(upUser),

    }).then(response => response.json()).
        then(data => {
            alert("👌המשתמש עודכן בהצלחה");
        }).catch(error => {
            console.log(error);
            //alert("😯תקלה בעדכון הפרטים");
        });
}