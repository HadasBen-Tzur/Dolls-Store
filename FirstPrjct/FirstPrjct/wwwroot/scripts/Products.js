function getDataCategory() {
    fetch("api/Categories/")
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                alert("לא נמצאו קטגוריות");
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            console.log(data);
            data.forEach(c => showAllCategories(c))
        })
        .catch(error => { console.log(error + "הייתה בעיה בהעלת הדף"); });
}

function getDataProduct() {
    count = 0;
    fetch("api/Products/")
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                alert("לא נמצאו מוצרים ");
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            console.log(data);
            data.forEach(p => showProduct(p))
        })
        .catch(error => { console.log(error + "הייתה בעיה בהעלת הדף"); });
}
var count = 0;
function showProduct(product) {
    count++;
    var url = ("./image/")
    x = document.getElementById("temp-card");
    var clonProduct = x.content.cloneNode(true);
    clonProduct.querySelector(".ProductName").innerHTML = product.productName;
    clonProduct.querySelector(".price").innerHTML = ' ₪' + product.price;
    clonProduct.querySelector(".description").innerHTML = product.description;
    clonProduct.querySelector("img").src = url + product.imageName;
    clonProduct.querySelector("button").addEventListener("click", () => {
        addToBag(product)
    });
    document.getElementById("PoductList").appendChild(clonProduct);
    var countJson = JSON.stringify(count);
    sessionStorage.setItem('counProducts', countJson);
    let counterProducts = sessionStorage.getItem('counProducts');
    document.getElementById("counter").innerHTML = counterProducts;
}

function showAllCategories(category) {
    x = document.getElementById("temp-category");
    var clonCategory = x.content.cloneNode(true);
    clonCategory.querySelector('.OptionName').innerHTML = category.categoryName;
    clonCategory.querySelector(".opt").addEventListener("change", function (event) {
        if (this.checked) {
            cleanData();
            showCategortById(category.categoryId);
        }
        else {
            cleanData();
            getDataProduct();
        }
    })
    document.getElementById("filters").appendChild(clonCategory);
}

function showCategortById(id) {
    count = 0;
    fetch("api/Products/" + id)
        .then(response => {
            if (response.ok)
                return response.json();
            else {
                throw new Error("status Code is:" + response.status);
            }
        })
        .then(data => {
            console.log(data);
            data.forEach(p => showProduct(p));
        });
}

function cleanData() {
    var elements = document.getElementsByClassName("card");
    while (elements.length > 0) {
        elements[0].parentNode.removeChild(elements[0]);
    }
}

let myBag = [];
function addToBag(product) {
    if (sessionStorage.getItem('amount') > 0) {
        myBag = JSON.parse(sessionStorage.getItem('product list'));
    }
    myBag.push(product);
    sessionStorage.setItem('product list', JSON.stringify(myBag));
    sessionStorage.setItem('amount', JSON.stringify(myBag.length));
    document.getElementById("ItemsCountText").innerText = myBag.length;
}