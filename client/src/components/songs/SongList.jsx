import { useEffect, useState } from "react";
import { getSongs } from "../../managers/songManager";
import { Link } from "react-router-dom";
import { Button, Table } from "reactstrap";

export const SongList = () => {
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    getSongs().then(setSongs);
  }, []);

  return (
    <>
      <h2>Songs in Production</h2>
      <div>
        {/* TODO: <Link to="/song/create">
          <Button>+Add Song</Button>
        </Link> */}
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
              <td>Details{/* TODO: <Link to={`/song/${s.id}`}>Details</Link> */}</td>
              <td>{/* TODO: Admin Delete */}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
