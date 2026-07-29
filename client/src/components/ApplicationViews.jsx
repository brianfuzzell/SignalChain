import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { GearList } from "./gear/GearList";
import { SongList } from "./songs/SongList";
import { CreateSong } from "./songs/CreateSong";
import { GearDetails } from "./gear/GearDetails";
import { CreateGear } from "./gear/CreateGear";
import { SongDetails } from "./songs/SongDetails";

export default function ApplicationViews({
  loggedInUser,
  setLoggedInUser,
  getInventory,
}) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GearList
                loggedInUser={loggedInUser}
                getInventory={getInventory} />
            </AuthorizedRoute>
          }
        />
        <Route path="gear">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <GearList
                  loggedInUser={loggedInUser}
                  getInventory={getInventory}
                />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreateGear getInventory={getInventory} />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <GearDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="songs">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <SongList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreateSong />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <SongDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route
        path="*"
        element={<h3>This isn't the path you're looking for...</h3>}
      />
    </Routes>
  );
}
