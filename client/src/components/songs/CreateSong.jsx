import { useEffect, useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getStatuses } from "../../managers/statusManager";
import { useNavigate } from "react-router-dom";
import { createSong } from "../../managers/songManager";

export const CreateSong = () => {
  const [title, setTitle] = useState("");
  const [writer, setWriter] = useState("");
  const [artist, setArtist] = useState("");
  const [yearRecorded, SetYearRecorded] = useState("");
  const [statusId, setStatusId] = useState("");
  const [statuses, setStatuses] = useState([]);
  const [errors, setErrors] = useState("");

  const navigate = useNavigate();

  useEffect(() => {
    getStatuses().then(setStatuses);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    const newSong = {
      title,
      writer,
      artist,
      yearRecorded: parseInt(yearRecorded),
      statusId: parseInt(statusId),
    };

    createSong(newSong).then((res) => {
      if (res.errors) {
        setErrors(res.errors);
      } else {
        navigate("/songs");
      }
    });
  };

  return (
    <>
      <div style={{ color: "red" }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(",")}
          </p>
        ))}
      </div>
      <h2>Add a Song</h2>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="title">Title</Label>
          <Input
            type="text"
            value={title}
            id="title"
            onChange={(e) => setTitle(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="writer">Writer</Label>
          <Input
            type="text"
            value={writer}
            id="writer"
            onChange={(e) => setWriter(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="artist">Artist</Label>
          <Input
            type="text"
            value={artist}
            id="artist"
            onChange={(e) => setArtist(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="year-recorded">Year Recorded</Label>
          <Input
            type="text"
            value={yearRecorded}
            id="year-recorded"
            onChange={(e) => SetYearRecorded(e.target.value)}
          />
        </FormGroup>
        <FormGroup>
          <Label for="status">Status</Label>
          <select
            value={statusId}
            onChange={(e) => setStatusId(e.target.value)}
          >
            <option value="">Song status</option>
            {statuses.map((s) => (
              <option key={s.id} value={s.id}>
                {s.name}
              </option>
            ))}
          </select>
        </FormGroup>
        <Button type="submit">Add</Button>
      </Form>
    </>
  );
};
