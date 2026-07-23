import { useEffect, useState } from "react";
import { deleteSong, getSongs } from "../../managers/songManager";
import { Link } from "react-router-dom";
import { Button, Table } from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashCan } from "@fortawesome/free-regular-svg-icons";

export const SongList = ({ loggedInUser }) => {
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    getSongs().then(setSongs);
  }, []);

  const handleDeleteSong = (id) => {
    deleteSong(id).then(() => {
      getSongs().then(setSongs);
    });
  };

  return (
    <div className="container container-padding" style={{ maxWidth: "800px" }}>
      <h2>Songs in Production</h2>
      <div>
        <Link to="/songs/create">
          <Button>+Add Song</Button>
        </Link>
      </div>
      <Table>
        <thead>
          <tr>
            <th>Song</th>
            <th>Status</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {songs.map((s) => (
            <tr key={s.id}>
              <td scope="row">{s.title}</td>
              <td>{s.status.name}</td>
              <td>
                <Link to={`/songs/${s.id}`}>Details</Link>
              </td>
              <td>
                {loggedInUser.roles.includes("Admin") &&
                s.status.name != "Released" ? (
                  <FontAwesomeIcon
                    className="delete-btn"
                    icon={faTrashCan}
                    style={{ color: "#666666" }}
                    onClick={() => handleDeleteSong(s.id)}
                  />
                ) : (
                  ""
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
