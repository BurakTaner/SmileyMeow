$(document).ready(function () {
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

  // $('#dis-city-select').change(function (e) {
  // });
});

const fetchCities = async () => {
  const cityList = fetch(`http://localhost:3000/getallcities`);
  const cityJSON = (await cityList).json();
  return await cityJSON;
};
