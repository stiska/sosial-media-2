import { useEffect, useState } from "react";
import UserProfile from "./UserProfile";

export default function NavBar({ currentUser }) {
  return (
    <div className="nav-bar">
      <div className="nav-bar-user">
        {currentUser == null ? (
          ""
        ) : (
          <UserProfile username={currentUser[0].username}></UserProfile>
        )}
      </div>
      <input className="search-bar" type="text" />
      <button className="home-button"></button>
    </div>
  );
}
