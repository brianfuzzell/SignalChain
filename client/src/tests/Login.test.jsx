import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import Login from "../components/auth/Login";
import * as authManager from "../managers/authManager";

afterEach(() => {
  vi.restoreAllMocks();
});

describe("login renders", () => {
  it("renders form elements", async () => {
    const { container } = render(
      <MemoryRouter>
        <Login setLoggedInUser={() => {}} />
      </MemoryRouter>,
    );
    expect(screen.getByRole("heading", { name: "Login" })).not.toBeNull();
    expect(screen.getByRole("textbox")).not.toBeNull();
    expect(container.querySelector('input[type="password"]')).not.toBeNull();

    const registerLink = screen.getByRole("link", { name: "here" });
    expect(registerLink.getAttribute("href")).toBe("/register");
  });

  it("calls authManager.login on successful submit", async () => {
    const user = userEvent.setup();
    const fakeUser = { roles: ["User"] };
    const loginSpy = vi.spyOn(authManager, "login").mockResolvedValue(fakeUser);
    const setLoggedInUser = vi.fn();

    const { container } = render(
      <MemoryRouter>
        <Login setLoggedInUser={setLoggedInUser} />
      </MemoryRouter>,
    );

    await user.type(screen.getByRole("textbox"), "test@example.com");
    await user.type(container.querySelector('input[type="password"]'), "password123");
    await user.click(screen.getByRole("button", { name: "Login" }))

    expect(loginSpy).toHaveBeenCalledWith('test@example.com', 'password123');
  });
});
