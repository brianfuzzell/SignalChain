import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter, Routes, Route } from "react-router-dom";
import { SongDetails } from "../components/songs/SongDetails";
import * as statusManager from "../managers/statusManager";
import * as songManager from "../managers/songManager";

vi.mock("../components/songs/GearUsedOnSong", () => ({
  GearUsedOnSong: () => null,
}));

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeSong = {
  id: 1,
  title: "White & Nerdy",
  writer: "'Weird Al' Yankovic",
  artist: "'Weird Al' Yankovic",
  yearRecorded: 2005,
  statusId: 1,
};

const fakeStatus = [{ id: 1, name: "Recording" }];

const renderSongDetails = (loggedInUser = { roles: ["Admin"] }) => {
  return render(
    <MemoryRouter initialEntries={["/songs/1"]}>
      <Routes>
        <Route
          path="/songs/:id"
          element={<SongDetails loggedInUser={loggedInUser} />}
        />
      </Routes>
    </MemoryRouter>,
  );
};

describe("SongDetails renders", () => {
  it("renders the song details heading and song title", async () => {
    vi.spyOn(songManager, "getSongById").mockResolvedValue(fakeSong);
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue([]);

    renderSongDetails();

    expect(
      await screen.findByRole("heading", { name: "Song Details" }),
    ).not.toBeNull();
    expect(screen.getByText("White & Nerdy")).not.toBeNull();
  });

  it("populates the form fields with the fetched song's data", async () => {
    vi.spyOn(songManager, "getSongById").mockResolvedValue(fakeSong);
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue(fakeStatus);

    const { container } = renderSongDetails();

    await screen.findByText("White & Nerdy");

    expect(screen.getByLabelText("Title").value).toBe("White & Nerdy");
    expect(screen.getByLabelText("Writer").value).toBe("'Weird Al' Yankovic");
    expect(screen.getByLabelText("Artist").value).toBe("'Weird Al' Yankovic");
    expect(screen.getByLabelText("Year Recorded").value).toBe("2005");
    expect(container.querySelector("select").value).toBe("1");
  });

  it("submits the edited form and calls updateSong", async () => {
    const user = userEvent.setup();
    vi.spyOn(songManager, "getSongById").mockResolvedValue(fakeSong);
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue(fakeStatus);

    const updateSpy = vi
      .spyOn(songManager, "updateSong")
      .mockResolvedValue(null);

    renderSongDetails();

    await screen.findByText("White & Nerdy");

    const titleInput = screen.getByLabelText("Title");
    await user.clear(titleInput);
    await user.type(titleInput, "Eat It");

    await user.click(screen.getByRole("button", { name: "Update" }));

    expect(updateSpy).toHaveBeenCalledWith(
      expect.objectContaining({
        title: "Eat It",
        writer: "'Weird Al' Yankovic",
        id: "1",
      }),
    );
  });
});
