const closeArea = async () => {
  $("#cnfrm-area")[0].style.display = "none";
  $("form").attr("action", "");
};

const revealArea = async () => {
  $("#cnfrm-area").css('display','block');
};

export const templateForm = (id,entityName,idElem) => {
 $(function () {
  const idd = id;
  const firstUpperName = `${entityName[0].toUpperCase() + entityName.slice(1)}`;
  const formName = $(`#${entityName}-form`);
  const titleForForm = $('#crud-title');
  const confSpamMsg = $('#cnfrm-spn');
  const formElements  = $("#form-group :input");
  
  if (!idd) {
    $("#crt-btn").css("display", "inline-block");
    
    titleForForm.text(`Create ${firstUpperName}`);
    
    $('#crt-btn').click(function (e) {
      confSpamMsg.text('create?');
      revealArea();
      formName.attr("action", `/A${firstUpperName}/Create`);
    
    });

    $("#cancl-frm").click(function (e) {
      closeArea();
    });
    

  } else {
    
    $("#ud-sec").css("display", "inline-block");
    
    titleForForm.text(`Read,Update and Delete ${firstUpperName}`);
    
    $("#updt-btn").click(function (e) {
      confSpamMsg.text('update?');
      revealArea();
      formName.attr("action", `/A${firstUpperName}/Update/${idd}`);
      formElements.prop('disabled',false);
      idElem.prop('disabled',true);
    });

    $("#dlt-btn").click(function (e) {
      confSpamMsg.text('delete?');
      revealArea();
      formName.attr("action", `/A${firstUpperName}/PostDelete/${idd}`);
      idElem.prop('disabled',true);
      
    });
    
    $("#cancl-frm").click(function (e) {
      closeArea();
      formElements.prop("disabled", true);
    });

  }
 });
}