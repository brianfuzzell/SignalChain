import { render, screen } from "@testing-library/react";
import { it, expect, describe, afterEach, vi } from "vitest";
import { GearUsedOnSong } from "../src/components/songs/GearUsedOnSong";

afterEach(() => {
  vi.restoreAllMocks();
});

const fakeSong = {
  id: 1,
  title: "White & Nerdy",
  gearUsed: [{ id: 1, model: "Neumann U 87 Ai" }],
};

describe("GearUsedOnSong renders", () => {
  it("renders the component heading", () => {
    render(<GearUsedOnSong song={{ gearUsed: [] }} />);

    expect(
      screen.getByRole("heading", { name: "Gear Used on This Song" }),
    ).not.toBeNull();
  });

  it("renders gear passed in through the song prop", () => {
    render(<GearUsedOnSong song={fakeSong} />);

    expect(screen.getByText("Neumann U 87 Ai")).not.toBeNull();
  });
});
