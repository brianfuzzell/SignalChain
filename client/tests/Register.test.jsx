import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { it, expect, describe, afterEach, vi } from "vitest";
import { MemoryRouter } from "react-router-dom";
import Register from "../src/components/auth/Register";
import * as authManager from "../src/managers/authManager";

afterEach(() => {
  vi.restoreAllMocks();
});

describe("register renders", () => {
  it("renders form elements", async () => {
    const { container } = render(
      <MemoryRouter>
        <Register setLoggedInUser={() => {}} />
      </MemoryRouter>,
    );
    expect(screen.getByRole("heading", { name: "Sign Up" })).not.toBeNull();
    expect(screen.getByLabelText("First Name").value).not.toBeNull();
    expect(screen.getByLabelText("Last Name").value).not.toBeNull();
    expect(container.querySelector('input[type="email"]').value).not.toBeNull();
    expect(screen.getByLabelText("User Name").value).not.toBeNull();
    expect(screen.getByLabelText("Address").value).not.toBeNull();
    expect(screen.getByLabelText("Password").value).not.toBeNull();
    expect(screen.getByLabelText("Confirm Password").value).not.toBeNull();

    const loginLink = screen.getByRole("link", { name: "here" });
    expect(loginLink.getAttribute("href")).toBe("/login");
  });

  it("calls authManager.register on successful submit", async () => {
    const user = userEvent.setup();
    const fakeUser = { roles: ["User"] };
    const registerSpy = vi
      .spyOn(authManager, "register")
      .mockResolvedValue(fakeUser);
    const setLoggedInUser = vi.fn();

    const { container } = render(
      <MemoryRouter>
        <Register setLoggedInUser={setLoggedInUser} />
      </MemoryRouter>,
    );

    await user.type(screen.getByLabelText("First Name"), "Test");
    await user.type(screen.getByLabelText("Last Name"), "User");
    await user.type(
      container.querySelector('input[type="email"]'),
      "test@example.com",
    );
    await user.type(screen.getByLabelText("User Name"), "testuser1");
    await user.type(screen.getByLabelText("Address"), "100 Main St.");
    await user.type(screen.getByLabelText("Password"), "password123");
    await user.type(screen.getByLabelText("Confirm Password"), "password123");
    await user.click(screen.getByRole("button", { name: "Register" }));

    expect(registerSpy).toHaveBeenCalledWith({
        firstName: "Test",
        lastName: "User",
        address: "100 Main St.",
        userName: "testuser1",
        email: "test@example.com",
        password: "password123"
    });
  });
});
