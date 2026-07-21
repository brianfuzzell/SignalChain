import { useEffect, useState } from "react";
import { assignSongToGear } from "../../managers/gearManager";
import { getSongs } from "../../managers/songManager";
import { Button } from "reactstrap";
import { useParams } from "react-router-dom";

export const AssignGearSong = ({ getGearDetails }) => {
  const { id } = useParams();
  const [songs, setSongs] = useState([]);
  const [selectedSongId, setSelectedSongId] = useState("");

  useEffect(() => {
    getSongs().then(setSongs);
  }, []);

  const handleAssignSong = () => {
    const newGearSong = {
      SongId: selectedSongId,
    };

    assignSongToGear(id, newGearSong).then(() => {
      setSelectedSongId("");
      getGearDetails(id);
    });
  };

  return (
    <>
      <h3>Assign Song to this Gear</h3>
      <div>
        <select
          value={selectedSongId}
          onChange={(e) => setSelectedSongId(e.target.value)}
        >
          <option value="">Assign Song</option>
          {songs.map((s) => (
            <option key={s.id} value={s.id}>
              {s.title}
            </option>
          ))}
        </select>
      </div>
      <Button onClick={() => handleAssignSong()}>Assign</Button>
    </>
  );
};
