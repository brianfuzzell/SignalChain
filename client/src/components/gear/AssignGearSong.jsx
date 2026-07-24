import { useEffect, useState } from "react";
import { assignSongToGear } from "../../managers/gearManager";
import { getSongs } from "../../managers/songManager";
import { Button, Input } from "reactstrap";
import { useParams } from "react-router-dom";

export const AssignGearSong = ({ getGearDetails }) => {
  const { id } = useParams();
  const [songs, setSongs] = useState([]);
  const [selectedSongId, setSelectedSongId] = useState("");
  const [errors, setErrors] = useState("");

  useEffect(() => {
    getSongs().then(setSongs);
  }, []);

  const handleAssignSong = () => {
    const newGearSong = {
      SongId: selectedSongId,
    };

    assignSongToGear(id, newGearSong).then((res) => {
      if (res === null) {
        setSelectedSongId("");
        getGearDetails(id);
      } else {
        setErrors(res);
      }
    });
  };

  return (
    <>
      <h3>Assign Song to this Gear</h3>
      <p style={{ color: "red" }} hidden={!errors}>
        {errors}
      </p>
      <div className="flex-form">
        <Input
          type="select"
          value={selectedSongId}
          onChange={(e) => setSelectedSongId(e.target.value)}
          className="assign-dropdown"
        >
          <option value="">Assign Song</option>
          {songs.map((s) => (
            <option key={s.id} value={s.id}>
              {s.title}
            </option>
          ))}
        </Input>
        <Button onClick={() => handleAssignSong()}>Assign</Button>
      </div>
    </>
  );
};
