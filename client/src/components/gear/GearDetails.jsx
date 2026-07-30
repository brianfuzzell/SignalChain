import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getGearById, getGears, updateGear } from "../../managers/gearManager";
import { getGearTypes } from "../../managers/gearTypeManager";
import { AssignGearSong } from "./AssignGearSong";
import { SongsUsingGear } from "./SongsUsingGear";

export const GearDetails = ({ loggedInUser }) => {
  const { id } = useParams();
  const [gears, setGears] = useState([]);
  const [gear, setGear] = useState(null);
  const [gearTypes, setGearTypes] = useState([]);
  const [formData, setFormData] = useState({
    gearTypeId: "",
    model: "",
    purchaseYear: "",
    quantity: "",
    serialNumber: "",
  });
  const [errors, setErrors] = useState("");
  const navigate = useNavigate();

  const getGearDetails = (id) => {
    getGearById(id).then(setGear);
  };

  useEffect(() => {
    getGears().then(setGears);
  }, []);

  useEffect(() => {
    getGearById(id).then((fetchedGear) => {
      setGear(fetchedGear);
      setFormData({
        gearTypeId: fetchedGear.gearTypeId,
        model: fetchedGear.model,
        purchaseYear: fetchedGear.purchaseYear,
        quantity: fetchedGear.quantity,
        serialNumber: fetchedGear.serialNumber,
      });
    });
  }, [id]);

  useEffect(() => {
    getGearTypes().then(setGearTypes);
  }, []);

  if (gear === null) return <p>Gear item not found.</p>;

  const handleEditGear = (event) => {
    event.preventDefault();

    const updatedGear = {
      ...formData,
      gearTypeId: parseInt(formData.gearTypeId),
      quantity: parseInt(formData.quantity),
      id,
    };

    updateGear(updatedGear).then((res) => {
      if (res === null) {
        navigate("/gear");
      } else {
        setErrors(res.errors);
      }
    });
  };

  return (
    <div className="container container-padding" style={{ maxWidth: "700px" }}>
      <div style={{ color: "#f6523f" }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(",")}
          </p>
        ))}
      </div>
      <h2>Gear Details</h2>
      <h4>{gear.model}</h4>
      <Form onSubmit={handleEditGear} className="flex-form">
        <FormGroup className="flex-fields">
          <Label for="type">Type</Label>
          <Input
            type="select"
            value={formData.gearTypeId}
            required
            onChange={(e) =>
              setFormData({ ...formData, gearTypeId: e.target.value })
            }
          >
            <option value="">Gear type</option>
            {gearTypes.map((gt) => (
              <option key={gt.id} value={gt.id}>
                {gt.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="model">Model</Label>
          <Input
            type="text"
            value={formData.model}
            id="model"
            required
            onChange={(e) =>
              setFormData({ ...formData, model: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="purchase-year">Purchase Year</Label>
          <Input
            type="number"
            value={formData.purchaseYear}
            id="purchase-year"
            required
            onChange={(e) =>
              setFormData({ ...formData, purchaseYear: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="quantity">Quantity</Label>
          <Input
            type="number"
            value={formData.quantity}
            id="quantity"
            required
            onChange={(e) =>
              setFormData({ ...formData, quantity: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup className="full-width">
          <Label for="serial-number">Serial Number</Label>
          <Input
            type="text"
            value={formData.serialNumber}
            id="serial-number"
            onChange={(e) =>
              setFormData({ ...formData, serialNumber: e.target.value })
            }
          />
        </FormGroup>
        <Button color="primary" type="submit" className="full-width">
          Update
        </Button>
      </Form>
      <SongsUsingGear
        getGearDetails={getGearDetails}
        gear={gear}
        loggedInUser={loggedInUser}
      />
      <AssignGearSong getGearDetails={getGearDetails} />
    </div>
  );
};
