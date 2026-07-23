const _apiUrl = "/api/song";

export const getSongs = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getSongById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const createSong = (song) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(song),
  }).then((res) => {
    if (res.ok) {
      return null;
    } else {
      return res.json();
    }
  });
};

export const updateSong = (song) => {
  return fetch(`${_apiUrl}/${song.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(song),
  }).then((res) => {
    if (res.ok) {
      return null;
    } else {
      return res.json();
    }
  });
};

export const deleteSong = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
  });
};
