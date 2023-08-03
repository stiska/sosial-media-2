import UserProfile from "./UserProfile";
export default function NavBar() {
  return (
    <div className="nav-bar">
      <button className="home-button">Home</button>

      <input className="search-bar" type="text" />
      <div className="nav-bar-user">
        <UserProfile></UserProfile>
      </div>
    </div>
  );
}
