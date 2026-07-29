import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavbarText,
} from "reactstrap";
import { logout } from "../managers/authManager";
import navLogo from "../assets/SC_nav_logo.png";

export default function NavBar({ loggedInUser, setLoggedInUser, inventory }) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar expand="lg" color="dark" dark>
        <div className="w-100">
          <div className="page-container d-flex align-items-center">
            <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
              <img src={navLogo} alt="Signal Chain" className="nav-logo" />
            </NavbarBrand>
            {loggedInUser ? (
              <>
                <NavbarToggler onClick={toggleNavbar} />
                <Collapse isOpen={open} navbar>
                  <Nav navbar>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink tag={RRNavLink} to="/gear">
                        Gear
                      </NavLink>
                    </NavItem>
                    <NavItem onClick={() => setOpen(false)}>
                      <NavLink tag={RRNavLink} to="/songs">
                        Songs
                      </NavLink>
                    </NavItem>
                  </Nav>
                </Collapse>
                {loggedInUser.roles.includes("Admin") && (
                  <NavbarText style={{ marginRight: "20px" }}>
                    Studio Inventory: {inventory}
                  </NavbarText>
                )}
                <Button
                  color="primary" outline
                  onClick={(e) => {
                    e.preventDefault();
                    setOpen(false);
                    logout().then(() => {
                      setLoggedInUser(null);
                      setOpen(false);
                    });
                  }}
                >
                  Logout
                </Button>
              </>
            ) : (
              <Nav navbar>
                <NavItem>
                  <NavLink tag={RRNavLink} to="/login">
                    <Button color="primary" outline>Login</Button>
                  </NavLink>
                </NavItem>
              </Nav>
            )}
          </div>
        </div>
      </Navbar>
    </div>
  );
}
