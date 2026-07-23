import { useEffect, useState } from "react";
import { Button, Table } from "reactstrap";
import { deleteGear, getGears } from "../../managers/gearManager";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTrashCan } from "@fortawesome/free-regular-svg-icons";

export const GearList = ({ loggedInUser }) => {
  const [gears, setGears] = useState([]);

  useEffect(() => {
    getGears().then(setGears);
  }, []);

  const handleDeleteGear = (id) => {
    deleteGear(id).then(() => {
      getGears().then(setGears);
    });
  };

  return (
    <div className="container container-padding" style={{ maxWidth: "800px" }}>
      <h2>Studio Gear</h2>
      <div>
        <Link to="/gear/create">
          <Button>+Add Gear</Button>
        </Link>
      </div>
      <Table>
        <thead>
          <tr>
            <th>Type</th>
            <th>Model</th>
            <th>Purchase Year</th>
            <th>Quantity</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {gears.map((g) => (
            <tr key={g.id}>
              <td scope="row">{g.gearType.name}</td>
              <td>{g.model}</td>
              <td>{g.purchaseYear}</td>
              <td>{g.quantity}</td>
              <td>
                <Link to={`/gear/${g.id}`}>Details</Link>
              </td>
              <td>
                {loggedInUser.roles.includes("Admin") ? (
                  <FontAwesomeIcon
                    className="delete-btn"
                    icon={faTrashCan}
                    style={{ color: "#666666" }}
                    onClick={() => handleDeleteGear(g.id)}
                  />
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
