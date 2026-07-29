import { cleanup, render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter, Routes, Route } from "react-router-dom";
import { GearDetails } from "../src/components/gear/GearDetails";
import * as gearManager from "../src/managers/gearManager";
import * as gearTypeManager from "../src/managers/gearTypeManager";
import * as songManager from "../src/managers/songManager";

afterEach(() => {
  cleanup();
  vi.restoreAllMocks();
});

const fakeGear = {
  id: 1,
  gearTypeId: 2,
  model: "Shure SM7B",
  purchaseYear: 2022,
  quantity: 2,
  serialNumber: "ABC123",
  songsUsingGear: [],
};

const fakeGearTypes = [{ id: 2, name: "Microphone" }];

const renderGearDetails = (loggedInUser = { roles: ["Admin"] }) => {
  return render(
    <MemoryRouter initialEntries={["/gear/1"]}>
      <Routes>
        <Route
          path="/gear/:id"
          element={<GearDetails loggedInUser={loggedInUser} />}
        />
      </Routes>
    </MemoryRouter>,
  );
};

describe("GearDetails renders", () => {
  it("renders the gear details heading and model name", async () => {
    vi.spyOn(gearManager, "getGears").mockResolvedValue([]);
    vi.spyOn(gearManager, "getGearById").mockResolvedValue(fakeGear);
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue([]);
    vi.spyOn(songManager, "getSongs").mockResolvedValue([]);

    renderGearDetails();

    expect(
      await screen.findByRole("heading", { name: "Gear Details" }),
    ).not.toBeNull();
    expect(screen.getByText("Shure SM7B")).not.toBeNull();
  });

  it("populates the form fields with the fetched gear's data", async () => {
    vi.spyOn(gearManager, "getGears").mockResolvedValue([]);
    vi.spyOn(gearManager, "getGearById").mockResolvedValue(fakeGear);
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue(fakeGearTypes);
    vi.spyOn(songManager, "getSongs").mockResolvedValue([]);

    const { container } = renderGearDetails();

    await screen.findByText("Shure SM7B");

    expect(screen.getByLabelText("Model").value).toBe("Shure SM7B");
    expect(screen.getByLabelText("Purchase Year").value).toBe("2022");
    expect(screen.getByLabelText("Quantity").value).toBe("2");
    expect(screen.getByLabelText("Serial Number").value).toBe("ABC123");
    expect(container.querySelector("select").value).toBe("2");
  });

  it("submits the edited form and calls updateGear", async () => {
    const user = userEvent.setup();
    vi.spyOn(gearManager, "getGears").mockResolvedValue([]);
    vi.spyOn(gearManager, "getGearById").mockResolvedValue(fakeGear);
    vi.spyOn(gearTypeManager, "getGearTypes").mockResolvedValue(fakeGearTypes);
    vi.spyOn(songManager, "getSongs").mockResolvedValue([]);
    const updateSpy = vi
      .spyOn(gearManager, "updateGear")
      .mockResolvedValue(null);

    renderGearDetails();

    await screen.findByText("Shure SM7B");

    const modelInput = screen.getByLabelText("Model");
    await user.clear(modelInput);
    await user.type(modelInput, "MD421");

    await user.click(screen.getByRole("button", { name: "Update" }));

    expect(updateSpy).toHaveBeenCalledWith(
      expect.objectContaining({
        model: "MD421",
        gearTypeId: 2,
        quantity: 2,
        id: "1",
      }),
    );
  });
});
