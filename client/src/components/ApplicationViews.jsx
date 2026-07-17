import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { GearList } from "./gear/GearList";
import { SongList } from "./songs/SongList";
import { CreateGear } from "./gear/CreateGear";
import { CreateSong } from "./songs/CreateSong";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <GearList />
            </AuthorizedRoute>
          }
        />
        <Route path="gear">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <GearList />
              </AuthorizedRoute>
            }
          />
          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreateGear />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="songs">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <SongList />
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
