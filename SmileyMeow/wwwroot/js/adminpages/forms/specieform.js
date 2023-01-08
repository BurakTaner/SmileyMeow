import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#specieid');
  const id = idElem.val();
  const entityName = "specie";

  templateForm(id,entityName,idElem);  
});
