import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#animalid');
  const id = idElem.val();
  const entityName = "petadopt";

  templateForm(id,entityName,idElem);  
});
