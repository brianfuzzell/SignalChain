import { Button, Table } from "reactstrap";
import { removeSongFromGear } from "../../managers/gearManager";
import { useParams } from "react-router-dom";

export const SongsUsingGear = ({ loggedInUser, getGearDetails, gear }) => {
  const { id } = useParams();

  const handleRemoveSong = (gearSongId) => {
    removeSongFromGear(gearSongId).then(() => {
      getGearDetails(id);
    });
  };

  return (
    <div className="container-padding">
      <h3>Songs Using This Gear</h3>
      <Table>
        <tbody>
          {gear.songsUsingGear.map((song, index) => (
            <tr key={index}>
              <td scope="row">{song.title}</td>
              <td>
                {loggedInUser.roles.includes("Admin") ? (
                  <Button outline onClick={() => handleRemoveSong(song.gearSongId)}>
                    Remove
                  </Button>
                ) : (
                  ""
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
