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
    <div className="container container-padding" style={{ maxWidth: "700px" }}>
      <h2>Songs in Production</h2>
      <div>
        <Link to="/songs/create">
          <Button>+Add Song</Button>
        </Link>
      </div>
      <div className="list">
        {songs.map((s) => (
          <div className="song-item" key={s.id}>
            <dl className="row">
              <div className="song-row-item-lrg">
                <dt>Song</dt>
                <dd>{s.title}</dd>
              </div>
              <div className="song-row-item-sm">
                <dt>Status</dt>
                <dd>{s.status.name}</dd>
              </div>
            </dl>
            <div className="row-actions">
              <div>
                <Link to={`/songs/${s.id}`}>Details</Link>
              </div>
              <div>
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
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};
