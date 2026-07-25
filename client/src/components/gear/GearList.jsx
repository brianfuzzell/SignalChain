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
      <div className="list">
        {gears.map((g) => (
          <div className="gear-item" key={g.id}>
            <dl className="row">
              <div className="row-item-lrg">
                <dt>Type</dt>
                <dd>{g.gearType.name}</dd>
              </div>
              <div className="row-item-lrg">
                <dt>Model</dt>
                <dd>{g.model}</dd>
              </div>
              <div className="row-item-sm">
                <dt>Purchase Year</dt>
                <dd>{g.purchaseYear}</dd>
              </div>
              <div className="row-item-sm">
                <dt>Quantity</dt>
                <dd>{g.quantity}</dd>
              </div>
            </dl>
            <div className="row-actions">
              <div>
                <Link to={`/gear/${g.id}`}>Details</Link>
              </div>
              <div>
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
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};
