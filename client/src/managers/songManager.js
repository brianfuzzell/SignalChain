const _apiUrl = "/api/song";

export const getSongs = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getSongById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const updateSong = (song) => {
  return fetch(`${_apiUrl}/${song.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(song),
  });
};