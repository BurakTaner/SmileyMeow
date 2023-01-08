import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#doctortitleid');
  const id = idElem.val();
  const entityName = "doctortitle";

  templateForm(id,entityName,idElem);  
});
