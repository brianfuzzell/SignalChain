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
      if (res === null) {
        navigate("/songs");
      } else {
        setErrors(res.errors);
      }
    });
  };

  return (
    <div className="container container-padding" style={{ maxWidth: "800px" }}>
      <div style={{ color: "red" }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(",")}
          </p>
        ))}
      </div>
      <h2>Add a Song</h2>
      <Form onSubmit={handleSubmit} className="flex-form">
        <FormGroup className="flex-fields">
          <Label for="title">Title</Label>
          <Input
            type="text"
            value={title}
            id="title"
            onChange={(e) => setTitle(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="writer">Writer</Label>
          <Input
            type="text"
            value={writer}
            id="writer"
            onChange={(e) => setWriter(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="artist">Artist</Label>
          <Input
            type="text"
            value={artist}
            id="artist"
            onChange={(e) => setArtist(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="year-recorded">Year Recorded</Label>
          <Input
            type="text"
            value={yearRecorded}
            id="year-recorded"
            onChange={(e) => SetYearRecorded(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="status">Status</Label>
          <Input
            type="select"
            value={statusId}
            onChange={(e) => setStatusId(e.target.value)}
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
          Add
        </Button>
      </Form>
    </div>
  );
};
