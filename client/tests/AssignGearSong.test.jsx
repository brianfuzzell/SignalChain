import { render, screen } from "@testing-library/react";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import * as songManager from "../src/managers/songManager";
import { AssignGearSong } from "../src/components/gear/AssignGearSong";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeSong = { id: 1, title: "White & Nerdy" };

describe("AssignGearSong renders", () => {
  it("renders the component heading", () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([]);

    render(
      <MemoryRouter>
        <AssignGearSong getGearDetails={() => {}} />
      </MemoryRouter>,
    );

    expect(
      screen.getByRole("heading", { name: "Assign Song to this Gear" }),
    ).not.toBeNull();
  });

  it("populates the Assign Song dropdown with fetched songs", async () => {
    vi.spyOn(songManager, "getSongs").mockResolvedValue([fakeSong]);

    render(
      <MemoryRouter>
        <AssignGearSong />
      </MemoryRouter>,
    );

    expect(await screen.findByText("White & Nerdy")).not.toBeNull();
  });
});
