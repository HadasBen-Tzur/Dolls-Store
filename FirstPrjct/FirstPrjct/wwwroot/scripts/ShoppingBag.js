var sum = 0;
let bagList = [];
function BagData() {
    let tmp = sessionStorage.getItem('product list');
    bagList = JSON.parse(tmp);
    bagList.forEach((p) => { sum += p.price });
    document.getElementById("totalAmount").innerHTML = sum + ' ₪';
    document.getElementById("itemCount").innerHTML = bagList.length;
    bagList.forEach((p, i) => showBagData(p, i))
}

function showBagData(bagItem, i) {
    tempCategory = document.getElementById("temp-row");
    var clonBag = tempCategory.content.cloneNode(true);
    var url = "url(./image/" + bagItem.imageName + ")";
    clonBag.querySelector(".image").style.backgroundImage = url;
    clonBag.querySelector(".itemName").innerHTML = bagItem.productName;
    clonBag.querySelector(".price").innerHTML = bagItem.price + ' ₪';
    clonBag.querySelector(".showText").addEventListener("click", () => {
        removeItem(bagItem.productId, i)
    });
    document.getElementById("items").appendChild(clonBag);
}
function removeItem(product, i) {
    let bagList = JSON.parse(sessionStorage.getItem('product list'));
    //let deleteItem = bagList.indexOf(product);
    bagList.splice(i, 1);
    sessionStorage.setItem('product list', JSON.stringify(bagList));
    cleanBag();
    sum = 0;
    BagData();
}
function cleanBag() {
    var elements = document.getElementsByClassName("item-row");
    while (elements.length > 0) {
        elements[0].parentNode.removeChild(elements[0]);
    }
}

//ביצוע הזמנה
function placeOrder() {

    let d = new Date();
    let day = d.getDate();
    let month = d.getMonth() + 1;
    let year = d.getFullYear();
    let toDay = day + "/" + month + "/" + year;
    let user = JSON.parse(sessionStorage.getItem('HiUser'));
    let orders = JSON.parse(sessionStorage.getItem('product list'));
    let orderList = [];
    for (let i in orders) {
        orderList.push({ ProductId: orders[i].productId, Quentity: 1 });
    };
    let order = {
        OrderDate: toDay,
        OrderSum: document.getElementById("totalAmount").innerText,
        UserId: user.userId,
        OrdersItem: orderList
    };
    fetch("api/Orders", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(order),
    }).then(response => {
        if (response.ok) {
            return response.json();
        }
        else response.json().then(err => { alert(JSON.stringify(err.errors)) });
    }).then(data => {
        alert(" הזמנתך בוצעה בהצלחה!  מספר הזמנה " + data.orderId);
    })
        .catch(error => { console.log(error); });
}