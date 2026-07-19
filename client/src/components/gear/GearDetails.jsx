import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { getGearById, getGears, updateGear } from "../../managers/gearManager";
import { getGearTypes } from "../../managers/gearTypeManager";
import { getGearTypeById } from "../../managers/gearTypeManager";

export const GearDetails = () => {
  const { id } = useParams();
  const [gears, setGears] = useState([]);
  const [gear, setGear] = useState(null);
  const [gearTypes, setGearTypes] = useState([]);
  const [gearType, setGearType] = useState(null);
  const [formData, setFormData] = useState({
    gearTypeId: "",
    model: "",
    purchaseYear: "",
    quantity: "",
    serialNumber: "",
  });
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
      id,
    };

    updateGear(updatedGear).then(() => {
      navigate("/gear");
    });
  };

  return (
    <>
      <h2>Gear Details</h2>
      <h4>{gear.model}</h4>
      <Form onSubmit={handleEditGear}>
        <FormGroup>
          <Label for="type">Type</Label>
          <select
            value={formData.gearTypeId}
            onChange={(e) => setFormData({ ...formData, gearTypeId: e.target.value })}
          >
            <option value="">Gear type</option>
            {gearTypes.map((gt) => (
              <option key={gt.id} value={gt.id}>
                {gt.name}
              </option>
            ))}
          </select>
        </FormGroup>
        <FormGroup>
          <Label for="model">Model</Label>
          <Input
            type="text"
            value={formData.model}
            id="model"
            onChange={(e) =>
              setFormData({ ...formData, model: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="purchase-year">Purchase Year</Label>
          <Input
            type="text"
            value={formData.purchaseYear}
            id="purchase-year"
            onChange={(e) =>
              setFormData({ ...formData, purchaseYear: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
          <Label for="quantity">Quantity</Label>
          <Input
            type="text"
            value={formData.quantity}
            id="quantity"
            onChange={(e) =>
              setFormData({ ...formData, quantity: e.target.value })
            }
          />
        </FormGroup>
        <FormGroup>
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
        <Button type="submit">Update</Button>
      </Form>
    </>
  );
};
