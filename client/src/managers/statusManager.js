const _apiUrl = "/api/status";

export const getStatuses = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getStatusById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};