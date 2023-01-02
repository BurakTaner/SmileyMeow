$(document).ready(function() {
    const secondSelect = $('#select-district')[0];
    const districtSelectLabel = $('#select-district-label');
    const selectCity = $('#select-city');
    const selectCityelem = $('#select-city')[0];
    const selectCityNotNull = $('#select-city-not-null');
    const secondSelectNotNull = $('#select-district-not-null')[0];
    const registerBtn = $('#register-btn')[0];
    fetchCities().then(
        cityList => {
            let firstOption = document.createElement('option');
            firstOption.value = null;
            firstOption.text = "Please select a city...";
            selectCity[0].add(firstOption);
            cityList.forEach(city => {
                let option = document.createElement('option'); 
                option.value = city.CityId;
                option.text = city.CityName;    
                selectCity[0].add(option);
            });
        }
    );
        

    selectCity.change(function() {
        $('#select-district').empty();
        let selectedCity = $(this).val();
        fetchDistricts(selectedCity).then(districtList => {
            let firstOption = document.createElement('option');
            firstOption.value = null;
            firstOption.text = "Please select a district...";
            secondSelect.add(firstOption);
            districtList.forEach(district => {
                let option = document.createElement('option'); 
                option.value = district.DistrictId;
                option.text = district.DistrictName;    
                secondSelect.add(option);
        })
        }).then(secondSelect.style.display = "block");
    });
    
    selectCityNotNull.change(function() {
        $('#select-district-not-null').empty();
        let selectedCity = $(this).val();
        fetchDistricts(selectedCity).then(districtList => {
            let firstOption = document.createElement('option');
            firstOption.value = null;
            firstOption.text = "Please select a district...";
            secondSelectNotNull.add(firstOption);
            districtList.forEach(district => {
                let option = document.createElement('option'); 
                option.value = district.DistrictId;
                option.text = district.DistrictName;    
                secondSelectNotNull.add(option);
        })
        });
    });

    $('#confirmation-box').change(function() {
        if($(this).prop('checked')) {
            registerBtn.disabled = false;
        }
        else {
            registerBtn.disabled = true;
        }
    })

});


// NodeJs Fetch
const fetchDistricts = async (selectedCity) =>  {
    const districtList = fetch(`http://localhost:3000/getdistrict/${selectedCity}`);
    const districtJSON = (await districtList).json();
    return await districtJSON;
};

const fetchCities = async () =>  {
    const cityList = fetch(`http://localhost:3000/getallcities`);
    const cityJSON = (await cityList).json();
    return await cityJSON;
};
