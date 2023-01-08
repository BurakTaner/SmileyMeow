import { fetchCities } from "../modules/fetch.js";

$(function () {
  fetchCities().then((cities) => {
    var firstOption = document.createElement("option");
    firstOption.text = "Select a city...";
    firstOption.value = 0;
    firstOption.name = "CityId"
    $('#dis-city-select')
    cities.forEach((city) => {
      var option = document.createElement("option");
      option.text = city.CityName;
      option.value = city.CityId;
      firstOption.name = "CityId"
      $('#dis-city-select').append(option);
    });
  });


});
