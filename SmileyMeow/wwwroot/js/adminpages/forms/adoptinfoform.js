$(function () {
    const formElements = $("#form-group :input");
    const idElem = $("#adoptinfoid");
    const id = idElem.val();
    const formName = $('#adoptinfo-form');
    const confSpamMsg = $('#cnfrm-spn');
    $("#updt-btn").click(function (e) {
      confSpamMsg.text('update?');

      revealArea();
      formName.attr("action", `/AAdoptInfo/Update/${id}`);
      formElements.prop('disabled',false);
      idElem.prop('disabled',true);
    });
  
    $("#dlt-btn").click(function (e) {
      confSpamMsg.text("delete?");
      revealArea();
      formName.attr("action", `/AAdoptInfo/PostDelete/${id}`);
      idElem.prop("disabled", true);
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
  