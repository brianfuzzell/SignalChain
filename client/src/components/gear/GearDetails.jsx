import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Button, Form, FormGroup, Input, Label } from "reactstrap"


export const GearDetails = () => {
    const { id } = useParams();
    const [gear, setGear] = useState(null);

    return (
        <>
            <h2>Gear Details</h2>
            <h4>{gear.model}</h4>
            <Form>
                <FormGroup>
                    <Label for="type">
                        Type
                    </Label>
                    <Input type="text" value="Type" id="type"/>
                </FormGroup>
                <FormGroup>
                    <Label for="model">
                        Model
                    </Label>
                    <Input type="text" value="Model" id="model"/>
                </FormGroup>
                <FormGroup>
                    <Label for="purchase-year">
                        Purchase Year
                    </Label>
                    <Input type="text" value="Purchase Year" id="purchase-year"/>
                </FormGroup>
                <FormGroup>
                    <Label for="quantity">
                        Quantity
                    </Label>
                    <Input type="text" value="Quantity" id="quantity"/>
                </FormGroup>
                <FormGroup>
                    <Label for="serial-number">
                        Serial Number
                    </Label>
                    <Input type="text" value="Serial Number" id="serial-number"/>
                </FormGroup>
                <Button type="submit">Update</Button>
            </Form>
        </>
    )
}