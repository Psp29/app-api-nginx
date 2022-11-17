import logo from "./logo.svg";
import "./App.css";
import { UserAdd } from "./UserAdd";
import { UserList } from "./UserList";
import { BrowserRouter, Route, NavLink, Routes } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="App Container">
        <h3 className="d-flex justify-content-center m-3">React Front-End</h3>

        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
          <ul className="navbar-nav">
            <li className="nav-item- m-1">
              <NavLink
                className="btn btn-light btn-outline-primary"
                to="/useradd"
              >
                Add Users
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink
                className="btn btn-light btn-outline-primary"
                to="/userlist"
              >
                List Users
              </NavLink>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/UserAdd" element={<UserAdd />} />
          <Route path="/UserList" element={<UserList />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
