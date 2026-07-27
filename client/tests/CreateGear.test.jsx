import { render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import { CreateGear } from "../src/components/gear/CreateGear";
import * as gearManager from "../src/managers/gearManager";
import * as gearTypeManager from "../src/managers/gearTypeManager";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeGearTypes = [{ id: 2, name: "Microphone" }];

describe("CreateGear renders", () => {
  it("renders the Add Gear heading", () => {
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue([]);

    render(
      <MemoryRouter>
        <CreateGear getInventory={() => {}} />
      </MemoryRouter>,
    );

    expect(screen.getByRole("heading", { name: "Add Gear" })).not.toBeNull();
  });

  it("populates the Type dropdown with fetched gear types", async () => {
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue(fakeGearTypes);

    render(
      <MemoryRouter>
        <CreateGear getInventory={() => {}} />
      </MemoryRouter>,
    );

    expect(await screen.findByText("Microphone")).not.toBeNull();
  });

  it("submits the form and calls createGear with the entered values", async () => {
    const user = userEvent.setup();
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue(fakeGearTypes);
    const createSpy = vi
      .spyOn(gearManager, "createGear")
      .mockResolvedValue(null);
    const getInventory = vi.fn();

    const { container } = render(
      <MemoryRouter>
        <CreateGear getInventory={getInventory} />
      </MemoryRouter>,
    );

    await screen.findByText("Microphone");

    await user.selectOptions(container.querySelector("select"), "2");
    await user.type(screen.getByLabelText("Model"), "Shure SM7B");
    await user.type(screen.getByLabelText("Purchase Year"), "2023");
    await user.type(screen.getByLabelText("Quantity"), "3");
    await user.type(screen.getByLabelText("Serial Number"), "XYZ789");

    await user.click(screen.getByRole("button", { name: "Add" }));

    expect(createSpy).toHaveBeenCalledWith({
      gearTypeId: 2,
      model: "Shure SM7B",
      purchaseYear: "2023",
      quantity: 3,
      serialNumber: "XYZ789",
    });

    await waitFor(() => {
      expect(getInventory).toHaveBeenCalled();
    });
  });
});
