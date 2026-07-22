import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getSongById, updateSong } from "../../managers/songManager";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getStatuses } from "../../managers/statusManager";
import { GearUsedOnSong } from "./GearUsedOnSong";

export const SongDetails = ({ loggedInUser }) => {
  const { id } = useParams();
  const [songs, setSongs] = useState([]);
  const [song, setSong] = useState(null);
  const [statuses, setStatuses] = useState([]);
  const [formData, setFormData] = useState({
    title: "",
    writer: "",
    artist: "",
    yearRecorded: "",
    statusId: "",
  });
  const navigate = useNavigate();

  useEffect(() => {
    getSongById(id).then((fetchedSong) => {
      setSong(fetchedSong);
      setFormData({
        title: fetchedSong.title,
        writer: fetchedSong.writer,
        artist: fetchedSong.artist,
        yearRecorded: fetchedSong.yearRecorded,
        statusId: fetchedSong.statusId,
      });
    });
  }, [id]);

  useEffect(() => {
    getStatuses().then(setStatuses);
  }, []);

  if (song === null) return <p>Song not found.</p>;

  const handleEditSong = (event) => {
    event.preventDefault();

    const updatedSong = {
      ...formData,
      id,
    };

    updateSong(updatedSong).then(() => {
      navigate("/songs");
    });
  };

  return (
    <>
      <h2>Song Details</h2>
      <h4>{song.title}</h4>
      <Form onSubmit={handleEditSong}>
        <FormGroup>
          <Label for="title">Title</Label>
          <Input
            type="text"
            value={formData.title}
            id="title"
            onChange={(e) =>
              setFormData({ ...formData, title: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="writer">Writer</Label>
          <Input
            type="text"
            value={formData.writer}
            id="writer"
            onChange={(e) =>
              setFormData({ ...formData, writer: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="artist">Artist</Label>
          <Input
            type="text"
            value={formData.artist}
            id="artist"
            onChange={(e) =>
              setFormData({ ...formData, artist: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="year-recorded">Year Recorded</Label>
          <Input
            type="text"
            value={formData.yearRecorded}
            id="year-recorded"
            onChange={(e) =>
              setFormData({ ...formData, yearRecorded: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="status">Status</Label>
          <select
            value={formData.statusId}
            onChange={(e) =>
              setFormData({ ...formData, statusId: e.target.value })
            }
          >
            <option value="">Song status</option>
            {statuses.map((s) => (
              <option key={s.id} value={s.id}>
                {s.name}
              </option>
            ))}
          </select>
        </FormGroup>
        <Button type="submit">Update</Button>
      </Form>
      <GearUsedOnSong song={song} />
    </>
  );
};
