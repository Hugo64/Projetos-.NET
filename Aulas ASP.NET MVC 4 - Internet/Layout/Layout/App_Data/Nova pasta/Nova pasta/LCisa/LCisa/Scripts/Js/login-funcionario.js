$(document).ready(function () {

  $("#listarFuncionarios, #tblExibir, #trocarDevolver, #btImprimir").hide();

  $("#list-func, #exibircompras, #exibirtroca, #finalizacompra").click(function () {
      $("#listarFuncionarios, #tblExibir, #trocarDevolver, #btImprimir").toggle();
  });

  //if ("codigoDaCompra == null") {
  //    $("#btImprimir").hide();
  //} else {
  //    $("#btImprimir").toggle();
  //}


});
