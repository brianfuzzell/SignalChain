import { Table } from "reactstrap";

export const GearUsedOnSong = ({ song }) => {

  return (
    <div className="container-padding">
      <h3>Gear Used on This Song</h3>
      <Table>
        <tbody>
          {song.gearUsed.map((gear, index) => (
            <tr key={index}>
              <td scope="row">{gear.model}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};
