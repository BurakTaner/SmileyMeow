$(function () {
  const formElements = $('#form-group :input');
    $("#updt-btn").click(function (e) {
    $('#cnfrm-msg').text("update?");
    revealArea();
    formElements.prop("disabled", false);
    $('#userrid').prop("disabled", true);
  });

  $("#cancl-frm").click(function (e) {
    closeArea();
    formElements.prop("disabled", true);
  });

});

const closeArea = async () => {
  $("#cnfrm-area")[0].style.display = "none";
  $("form").attr("action", "");
};

const revealArea = async () => {
  $("#cnfrm-area").css("display", "block");
};
