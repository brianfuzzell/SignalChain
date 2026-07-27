import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import { SongList } from "../src/components/songs/SongList";
import * as songManager from "../src/managers/songManager";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeInProgressSong = {
  id: 1,
  title: "White & Nerdy",
  status: { name: "Mixing" },
};

const fakeReleasedSong = {
  id: 1,
  title: "Amish Paradise",
  status: { name: "Released" },
};

describe("SongList renders", () => {
  it("renders the page heading", async () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([]);

    render(
      <MemoryRouter>
        <SongList loggedInUser={{ roles: [] }} />
      </MemoryRouter>,
    );

    expect(
      await screen.findByRole("heading", { name: "Songs in Production" }),
    ).not.toBeNull();
  });

  it("renders songs fetched from the server", async () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([fakeInProgressSong]);

    render(
      <MemoryRouter>
        <SongList loggedInUser={{ roles: ["User"] }} />
      </MemoryRouter>,
    );

    expect(await screen.findByText("White & Nerdy")).not.toBeNull();
    expect(screen.getByText("Mixing")).not.toBeNull();
  });

  it("hides the delete icon for a non-admin user", async () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([fakeInProgressSong]);

    const { container } = render(
      <MemoryRouter>
        <SongList loggedInUser={{ roles: ["User"] }} />
      </MemoryRouter>,
    );

    await screen.findByText("White & Nerdy");
    expect(container.querySelector(".delete-btn")).toBeNull();
  });

  it("shows the delete icon on in-progress songs for an admin user and deletes gear on click", async () => {
    const user = userEvent.setup();
    vi.spyOn(songManager, "getSongs").mockResolvedValue([fakeInProgressSong]);
    const deleteSpy = vi.spyOn(songManager, "deleteSong").mockResolvedValue({});

    const { container } = render(
      <MemoryRouter>
        <SongList loggedInUser={{ roles: ["Admin"] }} />
      </MemoryRouter>,
    );

    await screen.findByText("White & Nerdy");
    const deleteIcon = container.querySelector(".delete-btn");
    expect(deleteIcon).not.toBeNull();

    await user.click(deleteIcon);

    expect(deleteSpy).toHaveBeenCalledWith(1);
  });

  it("does not display delete icon on 'Released' songs for an admin user", async () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([fakeReleasedSong]);
    const deleteSpy = vi.spyOn(songManager, "deleteSong").mockResolvedValue({});

    const { container } = render(
      <MemoryRouter>
        <SongList loggedInUser={{ roles: ["Admin"] }} />
      </MemoryRouter>,
    );

    await screen.findByText("Amish Paradise");
    const deleteIcon = container.querySelector(".delete-btn");
    expect(deleteIcon).toBeNull();
    expect(deleteSpy).not.toHaveBeenCalled();
  });
});
