const _apiUrl = "/api/gear";

export const getGears = () => {
  return fetch(_apiUrl).then((res) => res.json());
};

export const getGearById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const createGear = (gear) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(gear),
  }).then((res) => res.json());
};

export const updateGear = (gear) => {
  return fetch(`${_apiUrl}/${gear.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(gear),
  });
};

export const removeSongFromGear = (id, songId) => {
  return fetch(`${_apiUrl}/${id}/songs/${songId}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
};

export const assignSongToGear = (id, newGearSong) => {
  return fetch(`${_apiUrl}/${id}/songs`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newGearSong),
  });
};

export const deleteGear = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
    });
};
