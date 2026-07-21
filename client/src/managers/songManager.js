const _apiUrl = "/api/song";

export const getSongs = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getSongById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};