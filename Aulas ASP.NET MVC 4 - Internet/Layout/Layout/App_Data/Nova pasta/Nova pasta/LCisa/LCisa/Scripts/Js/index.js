$(document).ready(function(){


$("#email").hide();

$("#checkbox").change(function(){

  $("#nome").slideToggle(500);
  $("#senha").slideToggle(500);
  $("#email").slideToggle(500);
  $("#cargo").slideToggle(500);


});

});
