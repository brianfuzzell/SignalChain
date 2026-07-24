import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getSongById, updateSong } from "../../managers/songManager";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getStatuses } from "../../managers/statusManager";
import { GearUsedOnSong } from "./GearUsedOnSong";

export const SongDetails = () => {
  const { id } = useParams();
  const [song, setSong] = useState(null);
  const [statuses, setStatuses] = useState([]);
  const [formData, setFormData] = useState({
    title: "",
    writer: "",
    artist: "",
    yearRecorded: "",
    statusId: "",
  });
  const [errors, setErrors] = useState("");
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
      statusId: parseInt(formData.statusId),
      id,
    };

    updateSong(updatedSong).then((res) => {
      if (res === null) {
        navigate("/songs");
      } else {
        setErrors(res.errors);
      }
    });
  };

  return (
    <div className="container container-padding" style={{ maxWidth: "700px" }}>
      <div style={{ color: "red" }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(",")}
          </p>
        ))}
      </div>
      <h2>Song Details</h2>
      <h4>{song.title}</h4>
      <Form onSubmit={handleEditSong} className="flex-form">
        <FormGroup className="flex-fields">
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
        <FormGroup className="flex-fields">
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
        <FormGroup className="flex-fields">
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
        <FormGroup className="flex-fields">
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
        <FormGroup className="full-width">
          <Label for="status">Status</Label>
          <Input
            type="select"
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
          </Input>
        </FormGroup>
        <Button type="submit" className="full-width">
          Update
        </Button>
      </Form>
      <GearUsedOnSong song={song} />
    </div>
  );
};
