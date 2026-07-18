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

// TODO: Delete a gear item
/* export const deleteGear = (id) => {
    return fetch(`${_apiUrl}/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
    });
}; */

// TODO: Assign gear item to a song

// TODO: Remove song from using gear item
