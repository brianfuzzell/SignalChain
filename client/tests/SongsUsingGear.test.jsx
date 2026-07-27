import { render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter, Route, Routes } from "react-router-dom";
import { SongsUsingGear } from "../src/components/gear/SongsUsingGear";
import * as gearManager from "../src/managers/gearManager";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeSongGear = {
  songsUsingGear: [{ gearSongId: 1, title: "White & Nerdy" }],
};

describe("SongsUsingThisGear renders", () => {
  it("renders the component heading", () => {
    render(
      <MemoryRouter>
        <SongsUsingGear
          loggedInUser={{ roles: [] }}
          gear={{ songsUsingGear: [] }}
        />
      </MemoryRouter>,
    );

    expect(
      screen.getByRole("heading", { name: "Songs Using This Gear" }),
    ).not.toBeNull();
  });

  it("renders songs passed in through the gear prop", () => {
    render(
      <MemoryRouter>
        <SongsUsingGear loggedInUser={{ roles: [] }} gear={fakeSongGear} />
      </MemoryRouter>,
    );

    expect(screen.getByText("White & Nerdy")).not.toBeNull();
  });

  it("hides the remove button for a non-admin user", async () => {
    render(
      <MemoryRouter>
        <SongsUsingGear loggedInUser={{ roles: [] }} gear={fakeSongGear} />
      </MemoryRouter>,
    );

    expect(screen.queryByRole("button", { name: "Remove" })).toBeNull();
  });

  it("shows the remove button for an admin user and deletes song on click", async () => {
    const user = userEvent.setup();
    const removeSpy = vi
      .spyOn(gearManager, "removeSongFromGear")
      .mockResolvedValue({});
    const getGearDetails = vi.fn();

    render(
      <MemoryRouter initialEntries={["/gear/1"]}>
        <Routes>
          <Route
            path="/gear/:id"
            element={
              <SongsUsingGear
                loggedInUser={{ roles: ["Admin"] }}
                gear={fakeSongGear}
                getGearDetails={getGearDetails}
              />
            }
          />
        </Routes>
      </MemoryRouter>,
    );

    const removeButton = screen.getByRole("button", { name: "Remove" });
    await user.click(removeButton);

    expect(removeSpy).toHaveBeenCalledWith(1);
    await waitFor(() => {
      expect(getGearDetails).toHaveBeenCalledWith("1");
    });
  });
});
