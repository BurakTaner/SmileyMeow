
import { templateForm } from "../../modules/formgeneral.js";

$(function () {
  const idElem = $('#roleeid');
  const id = idElem.val();
  const entityName = "rolee";

  templateForm(id,entityName,idElem);  
});
