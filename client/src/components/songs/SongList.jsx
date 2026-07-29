import { useEffect, useState } from "react";
import { deleteSong, getSongs } from "../../managers/songManager";
import { Link } from "react-router-dom";
import { Button } from "reactstrap";
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
      <div className="hdr-btn-wrapper">
        <div className="hdr-btn-h2">
          <h2>Songs in Production</h2>
        </div>
        <div className="hdr-btn">
          <Link to="/songs/create">
            <Button outline>+Add Song</Button>
          </Link>
        </div>
      </div>
      <div className="song-list">
        <div className="song-header">
          <dl className="specs">
            <div className="song-col-lrg">
              <dt>Song</dt>
              <dd></dd>
            </div>
            <div className="song-col-sm">
              <dt>Status</dt>
              <dd></dd>
            </div>
          </dl>
          <div className="row-actions">
            <div></div>
            <div></div>
          </div>
        </div>
      </div>
      <div className="song-list">
        {songs.map((s) => (
          <div className="song-row" key={s.id}>
            <dl className="specs">
              <div className="song-col-lrg">
                <dt></dt>
                <dd>{s.title}</dd>
              </div>
              <div className="song-col-sm">
                <dt></dt>
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
