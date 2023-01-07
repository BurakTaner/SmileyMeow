import { templateForm } from "../modules/formgeneral.js";

$(function () {
  const idElem = $('#petgenderid');
  const id = idElem.val();
  const entityName = "petgender";

  templateForm(id,entityName,idElem);  
});
