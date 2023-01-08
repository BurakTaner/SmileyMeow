export const fetchCities = async () => {
  const cityList = fetch(`http://localhost:3000/getallcities`);
  const cityJSON = (await cityList).json();
  return await cityJSON;
};


export const fetchDistricts = async (selectedCity) =>  {
  const districtList = fetch(`http://localhost:3000/getdistrict/${selectedCity}`);
  const districtJSON = (await districtList).json();
  return await districtJSON;
};
