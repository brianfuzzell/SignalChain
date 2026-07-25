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
      <div className="hdr-btn-wrapper">
        <div className="hdr-btn-h2">
          <h2>Studio Gear</h2>
        </div>
        <div className="hdr-btn">
          <Link to="/gear/create">
            <Button>+Add Gear</Button>
          </Link>
        </div>
      </div>
      <div className="gear-list">
        <div className="gear-header">
          <dl className="specs">
            <div className="gear-col-lrg">
              <dt>Type</dt>
              <dd></dd>
            </div>
            <div className="gear-col-lrg">
              <dt>Model</dt>
              <dd></dd>
            </div>
            <div className="gear-col-sm">
              <dt>Purchase Year</dt>
              <dd></dd>
            </div>
            <div className="gear-col-sm">
              <dt>Quantity</dt>
              <dd></dd>
            </div>
          </dl>
          <div className="row-actions">
            <div></div>
            <div></div>
          </div>
        </div>
      </div>
      <div className="gear-list">
        {gears.map((g) => (
          <div className="gear-row" key={g.id}>
            <dl className="specs">
              <div className="gear-col-lrg">
                <dt></dt>
                <dd>{g.gearType.name}</dd>
              </div>
              <div className="gear-col-lrg">
                <dt></dt>
                <dd>{g.model}</dd>
              </div>
              <div className="gear-col-sm">
                <dt></dt>
                <dd>{g.purchaseYear}</dd>
              </div>
              <div className="gear-col-sm">
                <dt></dt>
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
