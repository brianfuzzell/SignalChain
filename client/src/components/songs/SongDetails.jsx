import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getSongById } from "../../managers/songManager";

export const SongDetails = () => {
  const { id } = useParams();
  const [songs, setSongs] = useState([]);
  const [song, setSong] = useState(null);
  const [formData, setFormData] = useState({
    title: "",
    writer: "",
    artist: "",
    yearRecorded: "",
    statusId: "",
  });
  const navigate = useNavigate();

  const getSongDetails = (id) => {
    getSongById(id).then(setSong);
  };

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

  if (song === null) return <p>Song not found.</p>;

  return (
    <>
      <h2>Song Details</h2>
    </>
  );
};
