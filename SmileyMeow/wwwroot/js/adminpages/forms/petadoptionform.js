import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#animalid');
  const id = idElem.val();
  const entityName = "petadoption";

  templateForm(id,entityName,idElem);  
});
