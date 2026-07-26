import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";
import { getGearInventoryCount } from "./managers/gearManager";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const [inventory, setInventory] = useState(0);

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  const getInventory = () => {
    getGearInventoryCount().then(setInventory);
  };

  useEffect(() => {
    if (loggedInUser && loggedInUser.roles.includes("Admin")) {
      getInventory();
    }
  }, [loggedInUser]);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
        inventory={inventory}
      />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
        getInventory={getInventory}
      />
    </>
  );
}

export default App;
