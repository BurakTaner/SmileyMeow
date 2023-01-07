import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#breedid');
  const id = idElem.val();
  const entityName = "breed";

  templateForm(id,entityName,idElem);  
});
