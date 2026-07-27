import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import { CreateSong } from "../src/components/songs/CreateSong";
import * as songManager from "../src/managers/songManager";
import * as statusManager from "../src/managers/statusManager";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeStatus = [{ id: 1, name: "Recording" }];

describe("CreateSong renders", () => {
  it("renders the Add Song heading", () => {
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue([]);

    render(
      <MemoryRouter>
        <CreateSong />
      </MemoryRouter>,
    );

    expect(screen.getByRole("heading", { name: "Add a Song" })).not.toBeNull();
  });

  it("populates the Status dropdown with fetched song statuses", async () => {
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue(fakeStatus);

    render(
      <MemoryRouter>
        <CreateSong />
      </MemoryRouter>,
    );

    expect(await screen.findByText("Recording")).not.toBeNull();
  });

  it("submits the form and calls createSong with the entered values", async () => {
    const user = userEvent.setup();
    vi.spyOn(statusManager, "getStatuses").mockResolvedValue(fakeStatus);
    const createSpy = vi
      .spyOn(songManager, "createSong")
      .mockResolvedValue(null);

    const { container } = render(
      <MemoryRouter>
        <CreateSong />
      </MemoryRouter>,
    );

    await screen.findByText("Recording");

    await user.type(screen.getByLabelText("Title"), "White & Nerdy");
    await user.type(screen.getByLabelText("Writer"), "'Weird Al' Yankovic");
    await user.type(screen.getByLabelText("Artist"), "'Weird Al' Yankovic");
    await user.type(screen.getByLabelText("Year Recorded"), "2005");
    await user.selectOptions(container.querySelector("select"), "1");

    await user.click(screen.getByRole("button", { name: "Add" }));

    expect(createSpy).toHaveBeenCalledWith({
      title: "White & Nerdy",
      writer: "'Weird Al' Yankovic",
      artist: "'Weird Al' Yankovic",
      yearRecorded: 2005,
      statusId: 1,
    });
  });
});
