import { render, screen } from "@testing-library/react";
import { it, expect, describe } from "vitest";
import { MemoryRouter } from "react-router-dom";
import NavBar from "../components/NavBar";

describe("navbar renders links and button", () => {
  it("renders the brand name", () => {
    render(
      <MemoryRouter>
        <NavBar loggedInUser={null} setLoggedInUser={() => {}} inventory={0} />
      </MemoryRouter>,
    );
    expect(screen.getByText("Signal Chain")).not.toBeNull();
  });

  it("displays login button for visitors", () => {
    render(
      <MemoryRouter>
        <NavBar loggedInUser={null} setLoggedInUser={() => {}} inventory={0} />
      </MemoryRouter>,
    );
    expect(screen.getByText("Login")).not.toBeNull();
  });

  it("displays links & login button for authenticated users", () => {
    const fakeUser = { roles: ["User"] };
    render(
      <MemoryRouter>
        <NavBar
          loggedInUser={fakeUser}
          setLoggedInUser={() => {}}
          inventory={0}
        />
      </MemoryRouter>,
    );
    expect(screen.getByText("Gear")).not.toBeNull();
    expect(screen.getByText("Songs")).not.toBeNull();
    expect(screen.getByText("Logout")).not.toBeNull();
  });
});
