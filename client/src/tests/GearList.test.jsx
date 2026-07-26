import { render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import { GearList } from "../components/gear/GearList";
import * as gearManager from "../managers/gearManager";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeGear = {
  id: 1,
  model: "Shure SM7B",
  purchaseYear: 2022,
  quantity: 2,
  gearType: { name: "Microphone" },
};

describe("GearList renders", () => {
  it("renders the page heading", async () => {
    vi.spyOn(gearManager, "getGears").mockResolvedValue([]);

    render(
      <MemoryRouter>
        <GearList loggedInUser={{ roles: [] }} getInventory={() => {}} />
      </MemoryRouter>,
    );

    expect(
      await screen.findByRole("heading", { name: "Studio Gear" }),
    ).not.toBeNull();
  });

  it("renders gear fetched from the server", async () => {
    vi.spyOn(gearManager, "getGears").mockResolvedValue([fakeGear]);

    render(
      <MemoryRouter>
        <GearList loggedInUser={{ roles: ["User"] }} getInventory={() => {}} />
      </MemoryRouter>,
    );

    expect(await screen.findByText("Shure SM7B")).not.toBeNull();
    expect(screen.getByText("Microphone")).not.toBeNull();
    expect(screen.getByText("2022")).not.toBeNull();
    expect(screen.getByText("2")).not.toBeNull();
  });

  it("hides the delete icon for a non-admin user", async () => {
    vi.spyOn(gearManager, "getGears").mockResolvedValue([fakeGear]);

    const { container } = render(
      <MemoryRouter>
        <GearList loggedInUser={{ roles: ["User"] }} getInventory={() => {}} />
      </MemoryRouter>,
    );

    await screen.findByText("Shure SM7B");
    expect(container.querySelector(".delete-btn")).toBeNull();
  });

  it("shows the delete icon for an admin user and deletes gear on click", async () => {
    const user = userEvent.setup();
    vi.spyOn(gearManager, "getGears").mockResolvedValue([fakeGear]);
    const deleteSpy = vi.spyOn(gearManager, "deleteGear").mockResolvedValue({});
    const getInventory = vi.fn();

    const { container } = render(
      <MemoryRouter>
        <GearList
          loggedInUser={{ roles: ["Admin"] }}
          getInventory={getInventory}
        />
      </MemoryRouter>,
    );

    await screen.findByText("Shure SM7B");
    const deleteIcon = container.querySelector(".delete-btn");
    expect(deleteIcon).not.toBeNull();

    await user.click(deleteIcon);

    expect(deleteSpy).toHaveBeenCalledWith(1);
    await waitFor(() => {
      expect(getInventory).toHaveBeenCalled();
    });
  });
});
