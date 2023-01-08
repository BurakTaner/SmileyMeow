import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#doctorid');
  const id = idElem.val();
  const entityName = "doctorinformation";

  templateForm(id,entityName,idElem);  
});
