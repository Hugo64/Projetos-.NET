
function abrirMenu() {

    if (window.document.getElementById("menu-responsivo").style.display == "block")
    {
        window.document.getElementById("menu-responsivo").style.display = "none";
    }
    else
    {
        window.document.getElementById("menu-responsivo").style.display = "block";
    }
}

function abrirCarrinho() {
    window.location.href = "/Home/Carrinho";
}
