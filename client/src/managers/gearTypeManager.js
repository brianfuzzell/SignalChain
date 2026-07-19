const _apiUrl = "/api/geartype";

export const getGearTypes = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getGearTypeById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};