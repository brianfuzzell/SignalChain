import { render, screen } from "@testing-library/react";
import App from "../src/App";
import { afterEach, describe, it, vi } from "vitest";
import * as authManager from "../src/managers/authManager";
import { MemoryRouter } from "react-router-dom";

afterEach(() => {
  vi.restoreAllMocks();
});

describe("app renders", () => {
  it("renders without crashing", async () => {
    vi.spyOn(authManager, "tryGetLoggedInUser").mockResolvedValue(null);
    render(
      <MemoryRouter>
        <App />
      </MemoryRouter>,
    );
    await screen.findByText("Signal Chain");
  });
});
