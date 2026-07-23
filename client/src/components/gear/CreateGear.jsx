import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";
import { createGear } from "../../managers/gearManager";
import { getGearTypes } from "../../managers/gearTypeManager";

export const CreateGear = () => {
  const [gearTypeId, setGearTypeId] = useState("");
  const [model, setModel] = useState("");
  const [purchaseYear, setPurchaseYear] = useState("");
  const [quantity, setQuantity] = useState("");
  const [serialNumber, setSerialNumber] = useState("");
  const [errors, setErrors] = useState("");
  const [gearTypes, setGearTypes] = useState([]);

  useEffect(() => {
    getGearTypes().then(setGearTypes);
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    const newGear = {
      gearTypeId: parseInt(gearTypeId),
      model,
      purchaseYear,
      quantity: parseInt(quantity),
      serialNumber,
    };

    createGear(newGear).then((res) => {
      if (res === null) {
        navigate("/gear");
      } else {
        setErrors(res.errors);
      }
    });
  };

  const navigate = useNavigate();

  return (
    <div className="container container-padding" style={{ maxWidth: "800px" }}>
      <div style={{ color: "red" }}>
        {Object.keys(errors).map((key) => (
          <p key={key}>
            {key}: {errors[key].join(",")}
          </p>
        ))}
      </div>
      <h2>Add Gear</h2>
      <Form onSubmit={handleSubmit} className="flex-form">
        <FormGroup className="flex-fields">
          <Label for="gearTypeId">Type</Label>
          <Input
            type="select"
            value={gearTypeId}
            onChange={(e) => setGearTypeId(e.target.value)}
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
            value={model}
            id="model"
            onChange={(e) => setModel(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="purchase-year">Purchase Year</Label>
          <Input
            type="text"
            value={purchaseYear}
            id="purchase-year"
            onChange={(e) => setPurchaseYear(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="flex-fields">
          <Label for="quantity">Quantity</Label>
          <Input
            type="text"
            value={quantity}
            id="quantity"
            onChange={(e) => setQuantity(e.target.value)}
          />
        </FormGroup>
        <FormGroup className="full-width">
          <Label for="serial-number">Serial Number</Label>
          <Input
            type="text"
            value={serialNumber}
            id="serial-number"
            onChange={(e) => setSerialNumber(e.target.value)}
          />
        </FormGroup>
        <Button type="submit" className="full-width">
          Add
        </Button>
      </Form>
    </div>
  );
};
