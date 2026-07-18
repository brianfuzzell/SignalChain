import { useEffect, useState } from "react";
import { Button, Table } from "reactstrap";

import { getGears } from "../../managers/gearManager";

export const GearList = ({ loggedInUser }) => {
  const [gears, setGears] = useState([]);

  useEffect(() => {
    getGears().then(setGears);
  }, []);

  /*   const handleDeleteGear = (id) => {
    deleteGear(id).then(() => {
        getGears().then(setGears);
    });
  }; */

  return (
    <>
      <h2>Studio Gear</h2>
      <div>
        <Button>+Add Gear</Button>
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
              <td>Details</td>
              <td>
                Delete
                {/* {loggedInUser.roles.includes("Admin") ? (
                  <Button
                    onClick={() => handleDeleteGear(g.id)}
                    color="danger"
                  >
                    Delete
                  </Button>
                ) : (
                  ""
                )} */}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
